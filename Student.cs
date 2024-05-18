using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{

    [Table("Students")]
    class Student
    {
        [Key]public int idS { get; set; }

        private string name;
        private string clas;
        private int age;
        private string eventID;
        public string Name{ get { return name; } set { name = value; } }
        public string Clas { get { return clas; } set { clas = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string EventID { get { return eventID; } set { eventID = value; } }

        public Student() { }
        public Student(string name, string clas, int age) {
            this.name = name;
            this.clas = clas;
            this.age = age;
        }
        public Student(string name, string clas, int age, string EventID)
        {
            this.name = name;
            this.clas = clas;
            this.age = age;
            this.EventID = EventID;
        }
    }
}
