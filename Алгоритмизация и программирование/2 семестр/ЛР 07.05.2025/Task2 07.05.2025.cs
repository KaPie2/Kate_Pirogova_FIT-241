//3 класса, взаимодействуют между собой, но не наследники. Данные классов отображают БД товары.
//1 класс: описывает товар, где будет одно из полей (обязательное) – номер товара, наименование,
//2 класс: класс поставщиков, где обязательное поле – номер поставщика, наименование, контактный номер телефона,
//3 класс: движение товара, где поля – номер товара, номер поставщика, тип операции (поставка и продажа), количество, цена, дата.
//Наша БД целостная – не продаем те товары, которых нет; не закупаем, если товар не определен.
//Меню, будет доступ к следующим запросам:
//необходимо определить остатки по каждому товару (не продаем, чего нет),
//необходимо выдать поставки товаров, сгруппированных по поставщику,
//выдать продажи товаров, группированных по дате,
//выдать выручку от продаж, выдать поставщика, который поставил максимальное количество товаров (в шт).

using System;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace Task2
{
    class Goods
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Goods(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
    class Supplier
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public Supplier(string ID, string Name, string Number)
        {
            this.ID = ID;
            this.Name = Name;
            this.Number = Number;
        }
    }
    class Move
    {
        public string ID_goods { get; set; }
        public string ID_supplier { get; set; }
        public string Type { get; set; }
        public int Cnt { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public Move(string ID_goods, string ID_supplier, string Type, int Cnt, int Price, string Date)
        {
            this.ID_goods = ID_goods;
            this.ID_supplier = ID_supplier;
            this.Type = Type;
            this.Cnt = Cnt;
            this.Price = Price;
            this.Date = Date;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Goods> goodsDB = new List<Goods>
            {
                new Goods("1234", "Хлеб"), 
                new Goods("7890", "Молоко")
            };
            List<Supplier> suppliersDB = new List<Supplier>
            {
                new Supplier("6484", "Аркадий", "89456753214"),
                new Supplier("5243", "Снованова", "89487653214")
            };
            List<Move> moveDB = new List<Move>();
            while (true)
            {
                Console.WriteLine("1. Заполнить БД товаров");
                Console.WriteLine("2. Заполнить БД поставщиков");
                Console.WriteLine("3. Заполнить БД движения товаров");
                Console.WriteLine("4. Определить остатки по каждому товару");
                Console.WriteLine("5. Выдать поставки товаров, сгруппированных по поставщику");
                Console.WriteLine("6. Выдать продажи товаров, группированных по дате");
                Console.WriteLine("7. Выдать выручку от продаж");
                Console.WriteLine("8. Выдать поставщика, который поставил максимальное количество товаров (в шт)");
                Console.WriteLine("9. Выход");
                Console.Write("Выберите действие (введите только цифру): ");
                int move = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (move == 1)
                {
                    Console.Write("Введите ID товара: ");
                    string id = Console.ReadLine();
                    var id_equals = goodsDB.Where(g => g.ID == id).ToList();
                    if (id_equals.Count != 0) Console.WriteLine("Такой товар уже есть!");
                    else
                    {
                        Console.Write("Введите его наименование: ");
                        string name = Console.ReadLine();
                        goodsDB.Add(new Goods(id, name));
                        Console.WriteLine("Добавлено!\n");
                    }
                }
                else if (move == 2)
                {
                    Console.Write("Введите ID поставщика: ");
                    string id = Console.ReadLine();
                    var id_equals = suppliersDB.Where(s => s.ID == id).ToList();
                    if (id_equals.Count != 0) Console.WriteLine("Такой поставщик уже есть!");
                    else
                    {
                        Console.Write("Введите его наименование: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите его контактный телефон: ");
                        string number = Console.ReadLine();
                        suppliersDB.Add(new Supplier(id, name, number));
                        Console.WriteLine("Добавлено!\n");
                    }
                }
                else if (move == 3)
                {
                    Console.Write("Введите ID товара: ");
                    string id_goods = Console.ReadLine();
                    var id_goods_equals = goodsDB.Where(g => g.ID == id_goods).ToList();
                    if (id_goods_equals.Count == 0) Console.WriteLine("Такого товара нет в БД!");
                    else
                    {
                        Console.Write("Введите тип операции (\"поставка\" или \"продажа\"): ");
                        string type = Console.ReadLine();
                        string id_supplier = "0";
                        if (type == "поставка")
                        {
                            Console.Write("Введите ID поставщика: ");
                            id_supplier = Console.ReadLine();
                        }
                        var id_suppliers_equals = suppliersDB.Where(s => s.ID == id_supplier).ToList();
                        if (id_suppliers_equals.Count == 0 && id_supplier != "0") Console.WriteLine("Такого поставщика нет в БД!");
                        else
                        {
                            Console.Write("Введите количество товаров: ");
                            int cnt = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите цену товара за 1 шт: ");
                            int price = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите дату: ");
                            string date = Console.ReadLine();
                            moveDB.Add(new Move(id_goods, id_supplier, type, cnt, price, date));
                            Console.WriteLine("Добавлено!\n");
                        }
                    }
                }
                else if ((move == 4 || move == 5 || move == 6 || move == 7 || move == 8) && (goodsDB.Count * suppliersDB.Count * moveDB.Count) == 0) Console.WriteLine("Недостаточно данных!\n");
                else if (move == 4)
                {
                    var remains = moveDB.GroupBy(m => m.ID_goods).Select(g => new
                    {
                        goods_number = g.Key,
                        goods_name = goodsDB.FirstOrDefault(x => x.ID == g.Key).Name,
                        balance = g.Sum(m => m.Type == "поставка" ? m.Cnt : -m.Cnt)
                    }).OrderBy(x => x.goods_name);
                    Console.WriteLine("Остатки товаров:");
                    foreach (var item in remains)
                    {
                        Console.WriteLine($"ID товара: {item.goods_number}\nНаименование: {item.goods_name}\nОстаток: {item.balance}\n");
                    }
                }
                else if (move == 5)
                {
                    var supply = moveDB.Where(t => t.Type == "поставка").GroupBy(m => m.ID_supplier).Select(s => new
                    {
                        supplier_number = s.Key,
                        supplier_name = suppliersDB.FirstOrDefault(x => x.ID == s.Key).Name,
                        supply_details = s.Select(d => new
                        {
                            count_goods = d.Cnt,
                            date_supply = d.Date
                        })
                    }).OrderBy(x => x.supplier_name);
                    foreach (var item in supply)
                    {
                        Console.WriteLine($"Поставщик: \"{item.supplier_name}\", ID поставщика: {item.supplier_number}");
                        foreach(var data in item.supply_details)
                        {
                            Console.WriteLine($"Количество поставленного: {data.count_goods}\nДата: {data.date_supply}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (move == 6)
                {
                    var sale = moveDB.Where(t => t.Type == "продажа").GroupBy(m => m.Date).Select(g => new
                    {
                        date = g.Key,
                        sale_details = g.Select(d => new
                        {
                            goods_number = d.ID_goods,
                            goods_name = goodsDB.FirstOrDefault(x => x.ID == d.ID_goods).Name,
                            count_goods = d.Cnt
                        })
                    }).OrderBy(x => x.date);
                    foreach (var item in sale)
                    {
                        Console.WriteLine($"Дата: {item.date}");
                        foreach (var data in item.sale_details)
                        {
                            Console.WriteLine($"ID товара: {data.goods_number}\nНаименование: {data.goods_name}\nКоличество: {data.count_goods}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (move == 7)
                {
                    var totalRevenue = moveDB.Where(m => m.Type == "продажа").Sum(x => x.Cnt * x.Price);
                    Console.WriteLine($"Общая выручка: {totalRevenue} руб.\n");
                }
                else if (move == 8)
                {
                    var top_supplier = moveDB.Where(m => m.Type == "поставка") .GroupBy(m => m.ID_supplier).Select(g => new
                    {
                        supplier_number = g.Key,
                        supplier_name = suppliersDB.FirstOrDefault(s => s.ID == g.Key).Name,
                        total_supplied = g.Sum(m => m.Cnt)
                    }).OrderByDescending(x => x.total_supplied).FirstOrDefault();
                    Console.WriteLine("Поставщик с максимальными поставками:");
                    Console.WriteLine($"ID поставщика: {top_supplier.supplier_number}\nНаименование поставщика: {top_supplier.supplier_name}\nКоличество поставленных товаров: {top_supplier.total_supplied}\n");
                }
                else if (move == 9)
                {
                    Console.WriteLine("Выход программы\n");
                    break;
                }
                else Console.WriteLine("Данного действия не существует\n");
            }
        }
    }
}
