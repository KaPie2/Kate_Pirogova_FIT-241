//Есть класс с полями: номер телефона, оператор. Необходимо создать базу данных телефонов и определить с использованием словаря частоту 
//появления каждого оператора


using System;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    class Phone
    {
        public string Operator { get; set; }
        public string Number { get; set; }

        public Phone(string Operator, string Number)
        {
            this.Operator = Operator;
            this.Number = Number;
        }
    }

    class Programm
    {
        static void Main()
        {
            List<Phone> phoneDB = new List<Phone>();
            Dictionary<string, int> cnt = new Dictionary<string, int>();

            Console.Write("Введите количество номеров, которые будете вводить: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите {n} данных:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите номер телефона: ");
                string phone_number = Console.ReadLine();
                Console.Write($"Введите оператор связи: ");
                string mobile_operator = Console.ReadLine();
                Phone new_phone = new Phone(phone_number, mobile_operator);
                phoneDB.Add(new_phone);
            }

            foreach (var phones in phoneDB)
            {
                if (cnt.ContainsKey(phones.Number)) cnt[phones.Number] += 1;
                else cnt.Add(phones.Number, 1);
            }

            Console.WriteLine("Название оператора - количество телефонов, подключенных к нему");
            foreach (var el in cnt)
            {
                Console.WriteLine($"{el.Key} - {el.Value}");
            }
        }
    }
}
