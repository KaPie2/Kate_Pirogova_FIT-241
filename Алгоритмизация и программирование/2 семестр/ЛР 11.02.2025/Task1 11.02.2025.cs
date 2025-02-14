//Необходимо реализовать работу с базой данных телефонный справочник.
//Объекты характеризуются следующими значениями: ФИО, номер телефона (у одного человека может быть несколько телефонов),
//оператор связи (закреплен за телефоном), дата заключения телефона (год), город проживания человека (два класса, можно список или массив).
//Необходимо реализовать выборку по дате заключения договора, по оператору связи, по номеру телефона и по городу проживания (только владелец).
//Первый класс – телефон, характеризуется номером, оператором, датой заключения
//Второй класс – человек, характеризуется именем, городом проживания и списком объектов телефон

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Xml.Linq;

namespace Task1
{
    class Phone
    {
        public string Number { get; set; }
        public string Operator { get; set; }
        public int Year { get; set; }

        public Phone(string Number, string Operator, int Year)
        {
            this.Number = Number;
            this.Operator = Operator;
            this.Year = Year;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
        public Person(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
            PhoneNumbers = new List<Phone>();
        }

        public void AddPhone(Phone phone)
        {
            PhoneNumbers.Add(phone);
        }

    }

    class Programm
    {
        public static void PrintInformation(string name, string city, string phone_num, string mobile_operator, int year)
        {
            Console.WriteLine($"ФИО полльзователя: {name}");
            Console.WriteLine($"Город проживания: {city}");
            Console.WriteLine($"Номер телефона: {phone_num}");
            Console.WriteLine($"Оператор: {mobile_operator}");
            Console.WriteLine($"Год заключения: {year}\n");
        }

        static void Main()
        {
            List<Phone> phoneDB = new List<Phone>();
            List<Person> personDB = new List<Person>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Заполнить базу");
                Console.WriteLine("2. Поиск по дате заключения номера телефона");
                Console.WriteLine("3. Поиск по оператору связи");
                Console.WriteLine("4. Поиск по номеру телефона");
                Console.WriteLine("5. Поиск по городу проживания");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (move == 1)
                {
                    Console.Write("Введите ФИО человека: ");
                    string name = Console.ReadLine();
                    bool flag_number = true;
                    Console.Write("Введите город проживания: ");
                    string city = Console.ReadLine();
                    Person new_person = new Person(name, city);
                    Console.Write("Введите один из его номеров телефона: ");
                    string number = Console.ReadLine();
                    do
                    {
                        Console.Write("Введите оператор связи: ");
                        string mobile_operator = Console.ReadLine();
                        Console.Write("Введите год заключения телефона (только число): ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Phone new_phone = new Phone(number, mobile_operator, year);
                        new_person.AddPhone(new_phone);
                        phoneDB.Add(new_phone);
                        Console.Write("Введите еще один из его номеров телефона (для выхода введите 0): ");
                        number = Console.ReadLine();
                        if (number.Equals("0")) flag_number = false;
                    }
                    while (flag_number);
                    personDB.Add(new_person);
                    Console.WriteLine("Добавлено!\n");
                }
                else if ((move == 2 || move == 3 || move == 4 || move == 5) && personDB.Count == 0 && phoneDB.Count == 0) Console.WriteLine("В базе нет объектов!\n");
                else if (move == 2)
                {
                    Console.Write("Введите год заключения номера телефона: ");
                    int year_equal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    bool flag_years = false;
                    foreach (var person in personDB)
                    {
                        foreach (var phones in person.PhoneNumbers)
                        {
                            if (phones.Year == year_equal)
                            {
                                PrintInformation(person.Name, person.City, phones.Number, phones.Operator, phones.Year);
                                flag_years = true;
                            }
                        }
                    }
                    if (flag_years == false) Console.WriteLine("Таких пользователей не нашлось\n");
                }
                else if (move == 3)
                {
                    Console.Write("Введите оператор связи: ");
                    string operator_equal = Console.ReadLine();
                    Console.WriteLine();
                    bool flag_operator = false;
                    foreach (var person in personDB)
                    {
                        foreach (var phones in person.PhoneNumbers)
                        {
                            if (phones.Operator == operator_equal)
                            {
                                PrintInformation(person.Name, person.City, phones.Number, phones.Operator, phones.Year);
                                flag_operator = true;
                            }
                        }
                    }
                    if (flag_operator == false) Console.WriteLine("Таких пользователей не нашлось\n");
                }
                else if (move == 4)
                {
                    Console.Write("Введите номер телефона: ");
                    string number_equal = Console.ReadLine();
                    Console.WriteLine();
                    bool flag_number = false;
                    foreach (var person in personDB)
                    {
                        foreach (var phones in person.PhoneNumbers)
                        {
                            if (phones.Number == number_equal)
                            {
                                PrintInformation(person.Name, person.City, phones.Number, phones.Operator, phones.Year);
                                flag_number = true;
                            }
                        }
                    }
                    if (flag_number == false) Console.WriteLine("Таких пользователей не нашлось\n");
                }
                else if (move == 5)
                {
                    Console.Write("Введите город проживания: ");
                    string city_equal = Console.ReadLine();
                    Console.WriteLine();
                    bool flag_city = false;
                    foreach (var person in personDB)
                    {
                        if (person.City == city_equal)
                        {
                            Console.WriteLine($"ФИО полльзователя: {person.Name}");
                            Console.WriteLine($"Город проживания: {person.City}\n");
                            flag_city = true;
                        }
                    }
                    if (flag_city == false) Console.WriteLine("Таких пользователей не нашлось\n");
                }
                else if (move == 6)
                {
                    flag = false;
                    Console.WriteLine("Выход программы\n");
                }
                else Console.WriteLine("Данного действия не существует\n");
            }
        }
    }
}
