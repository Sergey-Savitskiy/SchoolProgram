   M S B A M L   `   `   `  ���� H  DSchoolProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SchoolProjectSchoolProject      SchoolProject.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:SchoolProject     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$0  *Реестр одаренных детей��$	��700��$
��1200�� � WindowStyle$
 None=�$	��700��$	��500�� � WindowStartupLocation$ CenterScreen=� � Icon$ /School.png�� � 
ResizeMode$ NoResize=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF7C22B1��� $ 	#FF1C2A77�� � Offset$ 1Q�.��� -   	 �Name$	 MainGrid��
 � RowDefinitions
 �� �� �� �� ��  � ColumnDefinitions �� �� �� �� �� .+��� -    ��Name$ 
AddStudent��$	��400��$��	15,0,15,0q�
�������$��Center=� �� Padding$ 30q�$	��550�� �� CornerRadius$ 15��$y�Hidden=�$��1��$��3��$��1��$��3�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$ 	#FF2F22CE��   ShadowDepth$ 0Q�._��� .+��� $��Новый ученик��$��22(�$
��Bold"�$��0 0 0 10q�$��Center=��� -    ��Name$ NameBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя ученика�� %  !MaterialDesignFloatingHintTextBox#��[  �� -   $ ClassBox��$ 
Класс��#��[  �� -   $ AgeBox��$ Возраст��#��[  �� -    ��Name$ EventID��$- 'Название мероприятия�� �� DisplayMemberPath$ 	EventName�� �� SelectedValuePath$ 	EventName�� & "MaterialDesignFloatingHintComboBox#��[  � Cursor$  ������ *Events+ �� SelectedValue �� *	EventName+� $��0,20,0,0q�.+��� -   $
��Left=�$��Создать��  MaterialDesignFlatButton#��[ �� -   $��Отмена��#��[ $��Right=��� -	   $ AddEvent��$	��400��$��	15,0,15,0q�
�������$��Center=�$ 30q�$	��550��$ 15��$y�Hidden=�$��1��$��3��$��1��$��2��   $ 20Q�$ 	#FF2F22CE��$ 0Q�._��� .+��� $'��!Новое мероприятие��$��22(�$
��Bold"�$��0 0 0 10q�$��Center=��� -
   $ 	NameEvent��$- 'Название мероприятия��#��[  �� -   $ 	TypeEvent��$# Тип мероприятия��#��[ .@��� $&�� Интеллектуальный���� $��Творческий���� $��Спортивный��(  "System.Windows.Controls.DatePicker  -     Name$ 	DateEvent��$% Дата мероприятия��  MaterialDesignDatePicker#��[ $	��0 1q�� $��0,20,0,0q�.+��� -   $
��Left=�$��Создать��#��[ �� -   $��Отмена��#��[ $��Right=��� -   $ EditStudent��$	��400��$��	15,0,15,0q�
�������$��Center=�$ 30q�$	��550��$ 15��$y�Hidden=�$��1��$��3��$��1��$��3��   $ 20Q�$ 	#FF2F22CE��$ 0Q�._��� .+��� $/��)Редактирование записи��$��22(�$
��Bold"�$��0 0 0 10q�$��Center=��� -   $ EditNameBox��$ Имя ученика��#��[  �� -   $ EditClassBox��$ 
Класс��#��[  �� -   $ 
EditAgeBox��$ Возраст��#��[  �� -   $ EditEventID��$- 'Название мероприятия��$ 	EventName��$ 	EventName��#��[ $  ������ *Events+ �� *	EventName+� $��0,20,0,0q�.+��� -   $
��Left=�$��Изменить��#��[ �� -   $��Отмена��#��[ $��Right=��� -   $ 	EditEvent��$	��400��$��	15,0,15,0q�
�������$��Center=�$ 30q�$	��550��$ 15��$y�Hidden=�$��1��$��3��$��1��$��2��   $ 20Q�$ 	#FF2F22CE��$ 0Q�._��� .+��� $/��)Редактирование записи��$��22(�$
��Bold"�$��0 0 0 10q�$��Center=��� -   $ EditNameEvent��$- 'Название мероприятия��#��[  �� -   $ EditTypeEvent��$# Тип мероприятия��#��[ .@��� $&�� Интеллектуальный���� $��Творческий���� $��Спортивный��  -   $ EditDateEvent��$% Дата мероприятия��#��[ $	��0 1q�� $��0,20,0,0q�.+��� -   $
��Left=�$��Изменить��#��[ �� -   $��Отмена��#��[ $��Right=��� -    ��Name$ 	CreateBtn��$��Создать��$
��Left=�$��
120,10,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -   $ EditBtn��$��Изменить��$
��Left=�$��
120,50,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -   $ DelBtn��$��Удалить��$
��Left=�$��
120,90,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -   $ 
CreateBtn2��$��Создать��$
��Left=�$��
120,10,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -    $ EditBtn2��$��Изменить��$
��Left=�$��
120,50,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -!   $ DelBtn2��$��Удалить��$
��Left=�$��
120,90,0,0q�$	��Top=�$��4��$��1��$��3��$��33��$	��100��$y�Hidden=��� -"   $��4��$��X��$
��Left=�$��
190,10,0,0q�$	��Top=�
���   ����	#FF5B0FAB$��	16,4,18,4q��� -#   $��4��$��-��$
��Left=�$��
140,10,0,0q�$	��Top=�
���   ����	#FF5B0FAB$��20(�$	��Top=��� -$   $��1��$��Ученики��$��Center=�$��0,10,0,0q�$	��Top=�
���   ����	#FF5B0FAB$��50��$	��138�� J� RenderTransformOrigin$ 0.366,0.626&��� -%   $��2��$��Мероприятия��$��Center=�$��0,11,0,0q�$	��Top=�
���   ����	#FF5B0FAB$��50��$	��136���� -&   $��3��$��Импорт в Excel��$��Center=�$��0,10,0,0q�$	��Top=�
���   ����	#FF5B0FAB$��50��$	��136��$y�Visible=�$
 Hand��&   System.Windows.Controls.DataGrid  -'     Name$ StudentDate��$��1��$��3��$��0��$��5��$��120,0,140,0q�   GridLinesVisibility$	 All=�   AutoGenerateColumns .      CanUserReorderColumns  .  !   CanUserResizeColumns! .  $y�Hidden=�"   SelectionMode$" Single=�#   SelectionUnit$# FullRow=�$   Columns$ 1  +MaterialDesignThemes.Wpf.DataGridTextColumn  -(   idSS��,  &System.Windows.Controls.DataGridColumn%   Header$% ID��&   
Visibility$& Hidden=�'   
IsReadOnly' . 1  +System.Windows.Controls.DataGridBoundColumn(   Binding( �� *idS+  -)   	nameS��$% ФИО��' . ( �� *Name+  -*   	clasS��$% 
Класс��' . ( �� *Clas+  -+   ageS��$% Возраст��' . ( �� *Age+  -,   eventID��$% Мероприятие��' . ( �� *	EventID+  --   $ 	EventData��$��1��$��3��$��0��$��5��$��120,0,140,0q�$	 All=� .    .  ! .  $y�Hidden=�$" Single=�$# FullRow=�$   -.   idEE��$% ID��$& Hidden=�' . ( �� *idE+  -/   	nameE��$% Название��' . ( �� *	EventName+  -0   	TypeE��$% Тип��' . ( �� *	EventType+  -1   	DateE��$% Дата��' . ( �� *	EventDate+