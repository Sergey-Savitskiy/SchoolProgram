using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Window = System.Windows.Window;

namespace SchoolProject
{
    public partial class MainWindow : Window
    {
        AppContext db;
        Student data;
        Event data2;
        
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();          
        }

        private void Button_AddS_Click(object sender, RoutedEventArgs e)
        {
            EventID.ItemsSource = db.Events.ToList();
            AddStudent.Visibility = Visibility.Visible;
            StudentDate.Visibility = Visibility.Hidden;
            CreateBtn.Visibility = Visibility.Hidden;
            EditBtn.Visibility = Visibility.Hidden;
            DelBtn.Visibility = Visibility.Hidden;
        }

        private void Button_AddSCancel_Click(object sender, RoutedEventArgs e)
        {
            AddStudent.Visibility = Visibility.Hidden;
            StudentDate.Visibility = Visibility.Visible;
            CreateBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Visible;
            DelBtn.Visibility = Visibility.Visible;
            NameBox.Text = "";
            ClassBox.Text = "";
            AgeBox.Text = "";
            EventID.Text = "";
        }

        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {        
            string name = NameBox.Text.Trim();
            string clas = ClassBox.Text.Trim();
            string age =  AgeBox.Text.Trim();
            string evenID = EventID.Text;

            if(string.IsNullOrWhiteSpace(name))
            {
                NameBox.ToolTip = "Нет данных";
                NameBox.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(clas))
            {
                ClassBox.ToolTip = "Нет данных";
                ClassBox.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(age.ToString()))
            {
                AgeBox.ToolTip = "Нет данных";
                AgeBox.Background = Brushes.DarkRed;
            }
            else if (Regex.IsMatch(name, @"^[a-zA-Z]+$") == true)
            {
                NameBox.ToolTip = "Переключите раскладку";
                NameBox.Background = Brushes.DarkRed;
            }
            else if (clas.Length > 3)
            {
                ClassBox.ToolTip = "Слишком много символов";
                ClassBox.Background = Brushes.DarkRed;
            }
            else if (int.Parse(age) > 18)
            {
                AgeBox.ToolTip = "Слишком большой возраст";
                AgeBox.Background = Brushes.DarkRed;
            }
            else
            {
                NameBox.ToolTip = "";
                NameBox.Background = Brushes.Transparent;
                ClassBox.ToolTip = "";
                ClassBox.Background = Brushes.Transparent;
                AgeBox.ToolTip = "";
                AgeBox.Background = Brushes.Transparent;

                if(evenID != null)
                {
                    Student student = new Student(name, clas, int.Parse(age), evenID);
                    db.Students.Add(student);
                } else
                {
                    Student student = new Student(name, clas, int.Parse(age));
                    db.Students.Add(student);
                }

                db.SaveChanges();
                MessageBox.Show("Запись создана", "Выполнено");
                StudentDate.ItemsSource = db.Students.ToList();
                AddStudent.Visibility = Visibility.Hidden;
                StudentDate.Visibility = Visibility.Visible;
                CreateBtn.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;
                DelBtn.Visibility = Visibility.Visible;

                NameBox.Text = "";
                ClassBox.Text = "";
                AgeBox.Text = "";
                EventID.Text = "";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Minimum_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ViewStd_Click(object sender, RoutedEventArgs e)
        {
            EventData.Visibility = Visibility.Hidden;
            CreateBtn2.Visibility = Visibility.Hidden;
            EditBtn2.Visibility = Visibility.Hidden;
            DelBtn2.Visibility = Visibility.Hidden;
            AddEvent.Visibility = Visibility.Hidden;
            EditEvent.Visibility = Visibility.Hidden;
            AddStudent.Visibility = Visibility.Hidden;
            EditStudent.Visibility = Visibility.Hidden;

            StudentDate.ItemsSource = db.Students.ToList();
            StudentDate.Visibility = Visibility.Visible;
            CreateBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Visible;
            DelBtn.Visibility = Visibility.Visible;
        }

        private void EditBtn_EditS_Click(object sender, RoutedEventArgs e)
        {
            EditEventID.ItemsSource = db.Events.ToList();
            Student Item = StudentDate.SelectedItem as Student;
            if(Item != null)
            {
                EditStudent.Visibility = Visibility.Visible;
                StudentDate.Visibility = Visibility.Hidden;
                CreateBtn.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;
                DelBtn.Visibility = Visibility.Hidden;
                data = Item;
                EditNameBox.Text = Item.Name;
                EditClassBox.Text = Item.Clas;
                EditAgeBox.Text = Item.Age.ToString();
                EditEventID.Text = Item.EventID;
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_EditStudent_Click(object sender, RoutedEventArgs e)
        {
            data.Name = EditNameBox.Text;
            data.Clas = EditClassBox.Text;
            data.Age = int.Parse(EditAgeBox.Text);

            if (string.IsNullOrWhiteSpace(EditNameBox.Text))
            {
                EditNameBox.ToolTip = "Нет данных";
                EditNameBox.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(EditClassBox.Text))
            {
                EditClassBox.ToolTip = "Нет данных";
                EditClassBox.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(EditAgeBox.Text))
            {
                EditAgeBox.ToolTip = "Нет данных";
                EditAgeBox.Background = Brushes.DarkRed;
            }
            else if (Regex.IsMatch(EditNameBox.Text, @"^[a-zA-Z]+$") == true)
            {
                EditNameBox.ToolTip = "Переключите раскладку";
                EditNameBox.Background = Brushes.DarkRed;
            }
            else if (EditClassBox.Text.Length > 3)
            {
                EditClassBox.ToolTip = "Слишком много символов";
                EditClassBox.Background = Brushes.DarkRed;
            }
            else if (int.Parse(EditAgeBox.Text) > 18)
            {
                EditAgeBox.ToolTip = "Слишком большой возраст";
                EditAgeBox.Background = Brushes.DarkRed;
            }
            else
            {
                EditNameBox.ToolTip = "";
                EditNameBox.Background = Brushes.Transparent;
                EditClassBox.ToolTip = "";
                EditClassBox.Background = Brushes.Transparent;
                EditAgeBox.ToolTip = "";
                EditAgeBox.Background = Brushes.Transparent;

                if (EditEventID.Text != "") {
                    data.EventID = EditEventID.Text;
                    db.Students.AddOrUpdate(this.data);
                    db.SaveChanges();
                } else
                {
                    db.Students.AddOrUpdate(this.data);
                    db.SaveChanges();
                }

                MessageBox.Show("Запись отредактирована", "Выполнено");
                StudentDate.ItemsSource = db.Students.ToList();

                data = null;
                EditStudent.Visibility = Visibility.Hidden;
                StudentDate.Visibility = Visibility.Visible;
                CreateBtn.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;
                DelBtn.Visibility = Visibility.Visible;
            }
        }

        private void Button_EditSCancel_Click(object sender, RoutedEventArgs e)
        {
            EditStudent.Visibility = Visibility.Hidden;
            StudentDate.Visibility = Visibility.Visible;
            CreateBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Visible;
            DelBtn.Visibility = Visibility.Visible;
            EditNameBox.Text = "";
            EditClassBox.Text = "";
            EditAgeBox.Text = "";
        }

        private void Button_DelS_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentDate.SelectedItem as Student;
            db.Students.Remove(student);
            db.SaveChanges();
            StudentDate.ItemsSource = db.Students.ToList();
        }

        private void Button_ViewEvent_Click(object sender, RoutedEventArgs e)
        {
            EventData.ItemsSource = db.Events.ToList();
            StudentDate.Visibility = Visibility.Hidden;
            CreateBtn.Visibility = Visibility.Hidden;
            EditBtn.Visibility = Visibility.Hidden;
            DelBtn.Visibility = Visibility.Hidden;
            AddStudent.Visibility = Visibility.Hidden;
            EditStudent.Visibility = Visibility.Hidden;
            AddEvent.Visibility = Visibility.Hidden;
            EditEvent.Visibility = Visibility.Hidden;

            EventData.Visibility = Visibility.Visible;
            CreateBtn2.Visibility = Visibility.Visible;
            EditBtn2.Visibility = Visibility.Visible;
            DelBtn2.Visibility = Visibility.Visible;
        }

        private void Button_AddE_Click(object sender, RoutedEventArgs e)
        {
            AddEvent.Visibility = Visibility.Visible;
            EventData.Visibility = Visibility.Hidden;
            CreateBtn2.Visibility = Visibility.Hidden;
            EditBtn2.Visibility = Visibility.Hidden;
            DelBtn2.Visibility = Visibility.Hidden;
            NameEvent.Text = "";
            TypeEvent.Text = "";
            DateEvent.Text = "";

        }

        private void Button_AddECancel_Click(object sender, RoutedEventArgs e)
        {
            AddEvent.Visibility = Visibility.Hidden;
            EventData.Visibility = Visibility.Visible;
            CreateBtn2.Visibility = Visibility.Visible;
            EditBtn2.Visibility = Visibility.Visible;
            DelBtn2.Visibility = Visibility.Visible;
            NameEvent.Text = "";
            TypeEvent.Text = "";
            DateEvent.Text = "";
        }

        private void Button_AddEvent_Click(object sender, RoutedEventArgs e)
        {
            string nameE = NameEvent.Text.Trim();
            string typeE = TypeEvent.Text;
            string DateE = DateEvent.Text;

            if (string.IsNullOrWhiteSpace(nameE))
            {
                NameEvent.ToolTip = "Нет данных";
                NameEvent.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(typeE))
            {
                TypeEvent.ToolTip = "Нет данных";
                TypeEvent.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(DateE))
            {
                DateEvent.ToolTip = "Нет данных";
                DateEvent.Background = Brushes.DarkRed;
            }
            else if (Regex.IsMatch(nameE, @"^[a-zA-Z]+$") == true)
            {
                NameEvent.ToolTip = "Переключите раскладку";
                NameEvent.Background = Brushes.DarkRed;
            }
            else
            {
                NameEvent.ToolTip = "";
                NameEvent.Background = Brushes.Transparent;
                TypeEvent.ToolTip = "";
                TypeEvent.Background = Brushes.Transparent;
                DateEvent.ToolTip = "";
                DateEvent.Background = Brushes.Transparent;

                Event even = new Event(nameE, typeE, DateE);

                db.Events.Add(even);
                db.SaveChanges();
                MessageBox.Show("Запись создана", "Выполнено");
                EventData.ItemsSource = db.Events.ToList();

                AddEvent.Visibility = Visibility.Hidden;
                EventData.Visibility = Visibility.Visible;
                CreateBtn2.Visibility = Visibility.Visible;
                EditBtn2.Visibility = Visibility.Visible;
                DelBtn2.Visibility = Visibility.Visible;
            }
        }

        private void Button_DelE_Click(object sender, RoutedEventArgs e)
        {
            Event even = EventData.SelectedItem as Event;
            db.Events.Remove(even);
            db.SaveChanges();
            EventData.ItemsSource = db.Events.ToList();
        }

        private void EditBtn_EditE_Click(object sender, RoutedEventArgs e)
        {
            Event Item = EventData.SelectedItem as Event;
            if (Item != null)
            {
                EditEvent.Visibility = Visibility.Visible;
                EventData.Visibility = Visibility.Hidden;
                CreateBtn2.Visibility = Visibility.Hidden;
                EditBtn2.Visibility = Visibility.Hidden;
                DelBtn2.Visibility = Visibility.Hidden;

                data2 = Item;
                EditNameEvent.Text = Item.EventName;
                EditTypeEvent.Text = Item.EventType;
                EditDateEvent.Text = Item.EventDate;
        }
            else
            {
                MessageBox.Show("Вы не выбрали строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

        private void Button_EditECancel_Click(object sender, RoutedEventArgs e)
        {
            EditEvent.Visibility = Visibility.Hidden;
            EventData.Visibility = Visibility.Visible;
            CreateBtn2.Visibility = Visibility.Visible;
            EditBtn2.Visibility = Visibility.Visible;
            DelBtn2.Visibility = Visibility.Visible;

            EditNameEvent.Text = "";
            EditTypeEvent.Text = "";
            EditDateEvent.Text = "";
        }

        private void Button_EditEvent_Click(object sender, RoutedEventArgs e)
        {
            data2.EventName = NameEvent.Text;
            data2.EventType = TypeEvent.Text;
            data2.EventDate = DateEvent.Text;

            if (string.IsNullOrWhiteSpace(NameEvent.Text))
            {
                NameEvent.ToolTip = "Нет данных";
                NameEvent.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(TypeEvent.Text))
            {
                TypeEvent.ToolTip = "Нет данных";
                TypeEvent.Background = Brushes.DarkRed;
            }
            else if (string.IsNullOrWhiteSpace(DateEvent.Text))
            {
                DateEvent.ToolTip = "Нет данных";
                DateEvent.Background = Brushes.DarkRed;
            }
            else if (Regex.IsMatch(NameEvent.Text, @"^[a-zA-Z]+$") == true)
            {
                NameEvent.ToolTip = "Переключите раскладку";
                NameEvent.Background = Brushes.DarkRed;
            }
            else
            {
                NameEvent.ToolTip = "";
                NameEvent.Background = Brushes.Transparent;
                TypeEvent.ToolTip = "";
                TypeEvent.Background = Brushes.Transparent;
                DateEvent.ToolTip = "";
                DateEvent.Background = Brushes.Transparent;

                db.Events.AddOrUpdate(this.data2);
                db.SaveChanges();
                MessageBox.Show("Запись отредактирована", "Выполнено");
                EventData.ItemsSource = db.Events.ToList();

                data2 = null;
                AddEvent.Visibility = Visibility.Hidden;
                EventData.Visibility = Visibility.Visible;
                CreateBtn2.Visibility = Visibility.Visible;
                EditBtn2.Visibility = Visibility.Visible;
                DelBtn2.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Import(object sender, RoutedEventArgs e)
        {
           Excel.Application ExcelFile = new Excel.Application();

            try
            {
                ExcelFile.Workbooks.Add(Type.Missing);

                ExcelFile.Interactive = false;
                ExcelFile.EnableEvents = false;

                Worksheet ExcelSheet = (Worksheet)ExcelFile.Sheets[1];
                ExcelSheet.Name = "Ученики";

                List<Student> dataDB = db.Students.ToList();
                List<Event> dataDB2 = db.Events.ToList();

                ExcelSheet.Cells[1] = "ID";
                ExcelSheet.Cells[2] = "ФИО";
                ExcelSheet.Cells[3] = "Класс";
                ExcelSheet.Cells[4] = "Возраст";
                ExcelSheet.Cells[5] = "Мероприятие";

                ExcelSheet.Cells[10] = "ID";
                ExcelSheet.Cells[11] = "Название мероприятия";
                ExcelSheet.Cells[12] = "Тип мероприятия";
                ExcelSheet.Cells[13] = "Дата мероприятия";

                for (int rowind = 0; rowind < dataDB.Count; rowind++)
                {
                        ExcelSheet.Cells[rowind + 2, 1] = dataDB[rowind].idS;
                        ExcelSheet.Cells[rowind + 2, 2] = dataDB[rowind].Name;
                        ExcelSheet.Cells[rowind + 2, 3] = dataDB[rowind].Clas;
                        ExcelSheet.Cells[rowind + 2, 4] = dataDB[rowind].Age;
                        ExcelSheet.Cells[rowind + 2, 5] = dataDB[rowind].EventID;

                        ExcelSheet.Cells[rowind + 2, 10] = dataDB2[rowind].idE;
                        ExcelSheet.Cells[rowind + 2, 11] = dataDB2[rowind].EventName;
                        ExcelSheet.Cells[rowind + 2, 12] = dataDB2[rowind].EventType;
                        ExcelSheet.Cells[rowind + 2, 13] = dataDB2[rowind].EventDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
       
            ExcelFile.Visible = true;
            ExcelFile.Interactive = true;
            ExcelFile.ScreenUpdating = true;
            ExcelFile.UserControl = true;
        }
    }
}
