//Первый класс Оценки – наименование предмета и оценка
//Второй класс Студент – поле ФИО, второе поле - массив из объектов класса оценки
//Меню – заполняем базу данных
//Если база заполнена: Первая выборка – выдать всех студентов, у которых средний балл выше, чем 4 или 5
//Нет наследников


using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Task2
{
    class Mark
    {
        public string Subject { get; set; }
        public int MarkValue { get; set; }

        public Mark(string Subject, int MarkValue)
        {
            this.Subject = Subject;
            this.MarkValue = MarkValue;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public Mark[] Marks { get; set; }

        public Student(string Name, Mark[] Marks)
        {
            this.Name = Name;
            this.Marks = Marks;
        }
    }

    class Programm
    {
        static void Main()
        {
            List<Student> studentDB = new List<Student>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Выборка по оценкам");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                if (move == 1)
                {
                    Console.Write("Введите имя студента: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите количество предметов: ");
                    int num_subjects = Convert.ToInt32(Console.ReadLine());
                    Mark[] marks = new Mark[num_subjects];
                    for (int i = 0; i < num_subjects; i++)
                    {
                        Console.Write("Введите название предмета: ");
                        string subject = Console.ReadLine();
                        Console.Write("Введите оценку за этот предмет: ");
                        int mark_of_subject = Convert.ToInt32(Console.ReadLine());
                        marks[i] = new Mark(subject, mark_of_subject);
                    }
                    Student new_student = new Student(name, marks);
                    studentDB.Add(new_student);
                    Console.WriteLine("Студент добавлен");
                }
                else if (move == 2 && studentDB.Count >= 2)
                {
                    List<Student> res_students = new List<Student>();
                    foreach (var el in studentDB)
                    {
                        double sum = 0;
                        double cnt = 0;
                        foreach (var mark in el.Marks)
                        {
                            sum += mark.MarkValue;
                            cnt ++;
                        }
                        double average_marks = sum / cnt;
                        if (average_marks > 4) res_students.Add(el);
                    }
                    if (res_students.Count > 0)
                    {
                        Console.WriteLine("Студенты, средний балл которых выше 4");
                        foreach (var el in res_students)
                        {
                            Console.WriteLine($"Имя: {el.Name}");
                        }
                    }
                    else Console.WriteLine("Таких студентов нет");
                }
                else if (move == 2 && studentDB.Count < 2) Console.WriteLine($"Недостаточно элементов! Добавьте в меню еще {2 - studentDB.Count} элемента");
                else if (move == 3)
                {
                    flag = false;
                    Console.WriteLine("Выход программы");
                }
                else Console.WriteLine("Данного действия не существует");
            }
        }
    }
}
