//Дан класс Печь, в котором выставляются поля: температура и длительность.
//Второй класс (наследник) – хлеб, в котором поля: поля от родителя, которые в Печи, наименование
//Необходимо создать меню, в котором будет заполнение базы данных (массив). Выборка по длительности (все что больше печется чем заданное время).
//Выборка по температурному режиму (хлеб, который печется при данной температуре)

using System;
using System.Threading;
using System.Timers;

namespace Task1
{
    class Bake
    {
        public int Temperature { get; set; }
        public int Time { get; set; }

        public Bake(int Temperature, int Time)
        {
            this.Temperature = Temperature;
            this.Time = Time;
        }
    }

    class Bread : Bake
    {
        public string Name { get; set; }

        public Bread(int Temperature, int Time, string Name) : base(Temperature, Time)
        {
            this.Name = Name;
        }
    }

    class Programm
    {
        static void Main()
        {
            List<Bread> breadDB = new List<Bread>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Добавить хлеб");
                Console.WriteLine("2. Выборка по длительности");
                Console.WriteLine("3. Выборка по температуре");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                if (move == 1)
                {
                    Console.Write("Введите название хлеба: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите температуру запекания (в Цельсия): ");
                    int temperature = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите длительность запекания (в минутах): ");
                    int time = Convert.ToInt32(Console.ReadLine());
                    Bread my_bread = new Bread(temperature, time, name);
                    breadDB.Add(my_bread);
                    Console.WriteLine("Хлеб добавлен");
                }
                else if (move == 2 && breadDB.Count >= 2)
                {
                    Console.Write("Введите минимальное время запекания (в минутах): ");
                    int min_time = Convert.ToInt32(Console.ReadLine());
                    var res_time = breadDB.FindAll(bread => bread.Time > min_time);
                    if (res_time.Count > 0)
                    {
                        Console.WriteLine("Хлеб, который печется больше заданного");
                        foreach (var el in res_time)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                        }
                    }
                    else Console.WriteLine("Такого хлеба нет");
                }
                else if (move == 3 && breadDB.Count >= 2)
                {
                    Console.Write("Введите температуру запекания (в Цельсиях): ");
                    int temp_equal = Convert.ToInt32(Console.ReadLine());
                    List<Bread> res_temp = new List<Bread>();
                    foreach (var el in breadDB)
                    {
                        if (el.Temperature == temp_equal) res_temp.Add(el);
                    }
                    if (res_temp.Count > 0)
                    {
                        Console.WriteLine("Хлеб, который запекаектся при данной температуре");
                        foreach (var el in res_temp)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                        }
                    }
                    else Console.WriteLine("Такого хлеба нет");
                }
                else if ((move == 2 || move == 3) && breadDB.Count < 2) Console.WriteLine($"Недостаточно элементов! Добавьте в меню еще {2 - breadDB.Count} элемента");
                else if (move == 4)
                {
                    flag = false;
                    Console.WriteLine("Выход программы");
                }
                else Console.WriteLine("Данного действия не существует");
            }
        }
    }
}
