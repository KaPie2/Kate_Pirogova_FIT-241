//Есть класс телефон(некая БД), где присутствуют следующие поля: номер телефона, владелец, год выпуска, оператор.
//Меню, которое позволит один из запросов: выдать все телефоны по заданному оператору связи,
//выдать данные по телефонам за заданный год,
//выдать все данные, сгруппированные по оператору связи,
//выдать все данные, сгруппированные по году выпуска.

using System;
using System.Linq;

namespace Task1
{
    class Phone
    {
        public string Number { get; set; }
        public string Person {  get; set; }
        public int Year { get; set; }
        public string Operator { get; set; }

        public Phone(string Number, string Person, int Year, string Operator)
        {
            this.Number = Number;
            this.Person = Person;
            this.Year = Year;
            this.Operator = Operator;
        }
    }

    class Programm
    {
        static void Main()
        {
            List<Phone> phoneDB = new List<Phone>();
            while (true)
            {
                Console.WriteLine("1. Заполнить базу");
                Console.WriteLine("2. Выдать все телефоны по заданному оператору связи");
                Console.WriteLine("3. Выдать данные по телефонам за заданный год");
                Console.WriteLine("4. Выдать все данные, сгруппированные по оператору связи");
                Console.WriteLine("5. Выдать все данные, сгруппированные по году выпуска");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (move == 1)
                {
                    Console.Write("Введите ФИО человека: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите его номер телефона: ");
                    string number = Console.ReadLine();
                    Console.Write("Введите оператор связи: ");
                    string mobile_operator = Console.ReadLine();
                    Console.Write("Введите год заключения телефона (только число): ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    phoneDB.Add(new Phone(number, name, year, mobile_operator));
                    Console.WriteLine("Добавлено!\n");
                }
                else if ((move == 2 || move == 3 || move == 4 || move == 5) && phoneDB.Count == 0) Console.WriteLine("База пуста!\n");
                else if (move == 2)
                {
                    Console.Write("Введите оператор связи: ");
                    string operator_equal = Console.ReadLine();
                    Console.WriteLine();
                    var selected_people_operator = phoneDB.Where(p => p.Operator == operator_equal).ToList();
                    if (selected_people_operator.Count == 0) Console.WriteLine("Таких пользователей не нашлось\n");
                    else
                    {
                        Console.WriteLine($"Номера с телефонов с \"{operator_equal}\" оператором связи:");
                        foreach (var data in selected_people_operator) Console.WriteLine(data.Number);
                        Console.WriteLine();
                    }
                }
                else if (move == 3)
                {
                    Console.Write("Введите год выпуска телефона: ");
                    int year_equal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    var selected_people_year = phoneDB.Where(p => p.Year == year_equal).ToList();
                    if (selected_people_year.Count == 0) Console.WriteLine("Таких пользователей не нашлось\n");
                    else
                    {
                        Console.WriteLine($"Данные телефонов {year_equal} года выпуска:");
                        foreach (var data in selected_people_year) Console.WriteLine($"Владелец: {data.Person}\nНомер телефона: {data.Number}\nОператор связи: {data.Operator}\n");
                    }
                }
                else if (move == 4)
                {
                    var mob_operators = phoneDB.GroupBy(p => p.Operator).ToList();
                    foreach(var oper in mob_operators)
                    {
                        Console.WriteLine(oper.Key);
                        foreach (var data in oper) Console.WriteLine($"Владелец: {data.Person}\nНомер телефона: {data.Number}\nГод: {data.Year}");
                        Console.WriteLine();
                    }
                }
                else if (move == 5)
                {
                    var years = phoneDB.GroupBy(p => p.Year).ToList();
                    foreach (var x in years)
                    {
                        Console.WriteLine(x.Key);
                        foreach (var data in x) Console.WriteLine($"Владелец: {data.Person}\nНомер телефона: {data.Number}\nОператор связи: {data.Operator}");
                        Console.WriteLine();
                    }
                }
                else if (move == 6)
                {
                    Console.WriteLine("Выход программы\n");
                    break;
                }
                else Console.WriteLine("Данного действия не существует\n");
            }
        }
    }
}
