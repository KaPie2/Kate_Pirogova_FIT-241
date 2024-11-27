//Упаковки молока

using System;

class Test
{
    static void Main()
    {
        double min_price_milk = int.MaxValue;
        int fab_ind = 0;
        Console.Write("Введите количество фабрик: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Введите рамзеры двух упаковов молока и их стоимость на {i}-й фабрике через пробел: ");
            var data = Console.ReadLine().Replace('.', ',').Split(' ');
            int x1 = Convert.ToInt32(data[0]);
            int y1 = Convert.ToInt32(data[1]);
            int z1 = Convert.ToInt32(data[2]);
            int x2 = Convert.ToInt32(data[3]);
            int y2 = Convert.ToInt32(data[4]);
            int z2 = Convert.ToInt32(data[5]);
            double price1 = Convert.ToDouble(data[6]);
            double price2 = Convert.ToDouble(data[7]);

            //площадь в см^2
            int s1 = 2 * (x1 * y1 + y1 * z1 + x1 * z1);
            int s2 = 2 * (x2 * y2 + y2 * z2 + x2 * z2);

            //объём в см^3
            double v1 = (x1 * y1 * z1);
            double v2 = (x2 * y2 * z2);

            double price_milk = 1000 * (price2 - price1 * s2 / s1) / (v2 - v1 * s2 / s1);

            if (price_milk < min_price_milk)
            {
                min_price_milk = price_milk;
                fab_ind = i;
            }
        }
        Console.WriteLine($"На {fab_ind}-й фабрике минимальная стоимость литра молока, равная {min_price_milk:0.00}");
    }
}
