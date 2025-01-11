//Два наследника одного класса
//Класс печка. Характеризоваться будет полями: температура, время приготовления (в мин)
//Два класса, которые будут являться наследниками класса печка
//Первый класс (наследник печки): хлеб + поля: наименование и вес (в гр)
//Второй класс (наследник печки): мясо + поля: наименование и вес (в гр)
//Меню по заполнению (база по хлебу и база по мясу), поиск по времени (и по хлебу, и по мясу), поиск по температурному режиму (и по хлебу, и по мясу), выход
//Выдать по заполнению, если нет одного из объекта, то написать об этом

using System;
using System.Threading;
using System.Timers;

namespace Task1
{
    class Oven
    {
        public int Temperature { get; set; }
        public int Time { get; set; }

        public Oven(int Temperature, int Time)
        {
            this.Temperature = Temperature;
            this.Time = Time;
        }
    }

    class Bread : Oven
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Bread(int Temperature, int Time, string Name, int Weight) : base(Temperature, Time)
        {
            this.Name = Name;
            this.Weight = Weight;
        }
    }

    class Meat : Oven
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Meat(int Temperature, int Time, string Name, int Weight) : base(Temperature, Time)
        {
            this.Name = Name;
            this.Weight = Weight;
        }
    }

    class Programm
    {
        static void Main()
        {
            List<Bread> breadDB = new List<Bread>();
            List<Meat> meatDB = new List<Meat>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Добавить хлеб");
                Console.WriteLine("2. Добавить мясо");
                Console.WriteLine("3. Поиск по длительности");
                Console.WriteLine("4. Поиск по температуре");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (move == 1)
                {
                    Console.Write("Введите название хлеба: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите температуру запекания (в Цельсия): ");
                    int temperature = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите длительность запекания (в минутах): ");
                    int time = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вес (в граммах): ");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Bread my_bread = new Bread(temperature, time, name, weight);
                    breadDB.Add(my_bread);
                    Console.WriteLine("Хлеб добавлен\n");
                }
                else if (move == 2)
                {
                    Console.Write("Введите название мяса: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите температуру запекания (в Цельсия): ");
                    int temperature = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите длительность запекания (в минутах): ");
                    int time = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вес (в граммах): ");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Meat my_meat = new Meat(temperature, time, name, weight);
                    meatDB.Add(my_meat);
                    Console.WriteLine("Мясо добавлено\n");
                }
                else if ((move == 3 || move == 4) && breadDB.Count == 0 && meatDB.Count == 0) Console.WriteLine("Продукты еще не добавлены!\n");
                else if (move == 3)
                {
                    if (breadDB.Count == 0) Console.WriteLine("В базе отсутствует хлеб!");
                    else if (meatDB.Count == 0) Console.WriteLine("В базе отстствует мясо!");
                    Console.Write("Введите время запекания (в минутах): ");
                    int time_equal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    List<Bread> res_time_bread = new List<Bread>();
                    foreach (var el in breadDB)
                    {
                        if (el.Time == time_equal) res_time_bread.Add(el);
                    }
                    List<Meat> res_time_meat = new List<Meat>();
                    foreach (var el in meatDB)
                    {
                        if (el.Time == time_equal) res_time_meat.Add(el);
                    }
                    if (res_time_bread.Count + res_time_meat.Count > 0)
                    {
                        Console.WriteLine($"Продукты, которые пекутся {time_equal} мин");
                        foreach (var el in res_time_bread)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                            Console.WriteLine($"Вес: {el.Weight}\n");
                        }
                        foreach (var el in res_time_meat)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                            Console.WriteLine($"Вес: {el.Weight}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого продукта нет\n");
                    }
                }
                else if (move == 4)
                {
                    if (breadDB.Count == 0) Console.WriteLine("В базе отсутствует хлеб!");
                    else if (meatDB.Count == 0) Console.WriteLine("В базе отстствует мясо!");
                    Console.Write("Введите температуру запекания (в Цельсиях): ");
                    int temp_equal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    List<Bread> res_temp_bread = new List<Bread>();
                    foreach (var el in breadDB)
                    {
                        if (el.Time == temp_equal) res_temp_bread.Add(el);
                    }
                    List<Meat> res_temp_meat = new List<Meat>();
                    foreach (var el in meatDB)
                    {
                        if (el.Time == temp_equal) res_temp_meat.Add(el);
                    }
                    if (res_temp_bread.Count + res_temp_meat.Count > 0)
                    {
                        Console.WriteLine($"Продукты, которые пекутся при температуре {temp_equal}");
                        foreach (var el in res_temp_bread)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                            Console.WriteLine($"Вес: {el.Weight}\n");
                        }
                        foreach (var el in res_temp_meat)
                        {
                            Console.WriteLine($"Наименование: {el.Name}");
                            Console.WriteLine($"Температура запекания: {el.Temperature}");
                            Console.WriteLine($"Время запекания: {el.Time}");
                            Console.WriteLine($"Вес: {el.Weight}\n");
                        }
                    }
                    else Console.WriteLine("Такого продукта нет\n");
                }
                else if (move == 5)
                {
                    flag = false;
                    Console.WriteLine("Выход программы\n");
                }
                else Console.WriteLine("Данного действия не существует\n");
            }
        }
    }
}
