//Задача магазин, то есть бд магазин. В ней будет отображаться поступление, продажа, просрочка (отправлено обратно поставщику).
//Структуру бд делаем сами. Надо получить выручку за определенный интервал времени,
//остатки на складе по каждому товару,
//списание товаров, отсортированное по товару,
//поставки, отсортированные по поставщику,
//продажи товаров, отсортированные по дате продажи.
//Ограничение: поставщик может повторяться несколько раз следовательно отдельный класс, товары тоже отдельный класс. Через LINQ

using System;
using System.Linq;
using System.Collections.Generic;

namespace Task1
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Goods(int Id, string Name, decimal Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
        }
    }

    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Supplier(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }

    public class Delivery
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Delivery(int Id, int ProductId, int SuppliedId, int Quantity, DateTime Date, DateTime ExpiryDate)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.SupplierId = SuppliedId;
            this.Quantity = Quantity;
            this.Date = Date;
            this.ExpiryDate = ExpiryDate;
        }
    }

    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Sale(int Id, int ProductId, int Quantity, DateTime Date)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
            this.Date = Date;
        }
    }

    public class WriteOff
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime WriteOffDate { get; set; }
        public WriteOff(int Id, int ProductId, int Quantity, DateTime WriteOffDate)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
            this.WriteOffDate = WriteOffDate;
        }
    }

    public class ShopDataBase
    {
        public List<Supplier> SuppliersDB { get; set; } = new List<Supplier>();
        public List<Goods> GoodsDB { get; set; } = new List<Goods>();
        public List<Delivery> DeliveriesDB { get; set; } = new List<Delivery>();
        public List<Sale> SalesDB { get; set; } = new List<Sale>();
        public List<WriteOff> WriteOffsDB { get; set; } = new List<WriteOff>();
    }

    class Program
    {
        static void Main()
        {
            var shopDB = new ShopDataBase();

            shopDB.GoodsDB.AddRange(new[]
            {
                new Goods(1, "Молоко", 70),
                new Goods(2, "Хлеб", 40),
                new Goods(3, "Яйца", 90)
            });

            shopDB.SuppliersDB.AddRange(new[]
            {
                new Supplier(1,"Молочный завод"),
                new Supplier(2, "Хлебозавод"),
                new Supplier(3, "Птицефабрика")
            });

            shopDB.DeliveriesDB.AddRange(new[]
            {
                new Delivery(1, 1, 1, 100, new DateTime(2025, 1, 1), new DateTime(2025, 2, 1)),
                new Delivery(2, 2, 2, 200, new DateTime(2025, 1, 2), new DateTime(2025, 1, 15)),
                new Delivery(3, 3, 3, 150, new DateTime(2025, 1, 3), new DateTime(2025, 2, 10))
            });

            shopDB.SalesDB.AddRange(new[]
            {
                new Sale(1, 1, 50, new DateTime(2025, 1, 5)),
                new Sale(2, 2, 100, new DateTime(2025, 1, 6)),
                new Sale(3, 3, 75, new DateTime(2025, 1, 7))
            });

            shopDB.WriteOffsDB.AddRange(new[]
            {
                new WriteOff(1, 1, 10, new DateTime(2025, 1, 10)),
                new WriteOff(2, 2, 5, new DateTime(2025, 1, 12))
            });

            //1. выручка за определенный интервал времени
            DateTime start = new DateTime(2025, 1, 1);
            DateTime end = new DateTime(2025, 1, 31);
            var revenue = shopDB.SalesDB.Where(s => s.Date >= start && s.Date <= end)
            .Join(shopDB.GoodsDB, sale => sale.ProductId, goods => goods.Id, (sale, goods) => sale.Quantity * goods.Price).Sum();
            Console.WriteLine($"Выручка с {start.ToShortDateString()} по {end.ToShortDateString()}: {revenue} руб.\n");

            //2. остатки на складе по каждому товару
            Console.WriteLine("Остатки на складе:");
            var stock = shopDB.GoodsDB.Select(g => new
            {
                g.Name,
                Quantity = shopDB.DeliveriesDB.Where(d => d.ProductId == g.Id).Sum(d => d.Quantity)
                              - shopDB.SalesDB.Where(s => s.ProductId == g.Id).Sum(s => s.Quantity)
                              - shopDB.WriteOffsDB.Where(w => w.ProductId == g.Id).Sum(w => w.Quantity)
            });
            foreach (var el in stock) Console.WriteLine($"{el.Name}: {el.Quantity} шт.");

            //3. списание товаров, отсортированное по товару
            Console.WriteLine("\nСписание товаров:");
            var write_offs = shopDB.WriteOffsDB.OrderBy(w => shopDB.GoodsDB.First(g => g.Id == w.ProductId).Name).Select(w => new
            {
                Product = shopDB.GoodsDB.First(g => g.Id == w.ProductId).Name,
                w.Quantity,
                w.WriteOffDate
            });
            foreach (var el in write_offs) Console.WriteLine($"{el.Product}: {el.Quantity} шт. (дата: {el.WriteOffDate.ToShortDateString()})");

            //4. поставки, отсортированные по поставщику
            Console.WriteLine("\nПоставки по поставщикам:");
            var deliv_by_supplier = shopDB.DeliveriesDB.GroupBy(d => d.SupplierId).OrderBy(g => shopDB.SuppliersDB.First(s => s.Id == g.Key).Name)
                .Select(g => new
                {
                    Supplier = shopDB.SuppliersDB.First(s => s.Id == g.Key).Name,
                    Deliveries = g.Select(d => new
                    {
                        Product = shopDB.GoodsDB.First(p => p.Id == d.ProductId).Name,
                        d.Quantity,
                        d.Date
                    })
                });
            foreach (var supp in deliv_by_supplier)
            {
                Console.WriteLine(supp.Supplier);
                foreach (var deliv in supp.Deliveries) Console.WriteLine($" {deliv.Product}: {deliv.Quantity} шт. (дата: {deliv.Date.ToShortDateString()})");
            }

            //5. продажи товаров, отсортированные по дате продажи
            Console.WriteLine("\nПродажи по дате:");
            var sales_by_date = shopDB.SalesDB.OrderBy(s => s.Date).Select(s => new
            {
                Product = shopDB.GoodsDB.First(g => g.Id == s.ProductId).Name,
                s.Quantity,
                s.Date
            });
            foreach (var el in sales_by_date) Console.WriteLine($"{el.Date.ToShortDateString()}: {el.Product} - {el.Quantity} шт.");
        }
    }
}
