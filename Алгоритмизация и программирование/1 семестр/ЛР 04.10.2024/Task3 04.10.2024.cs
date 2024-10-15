//Дана последовательность из n элементов (массивы не знаем)
//Определить максимальную сумму подпоследовательности из четных элементов.

using System;

class Task3
{
    static void Main()
    {
        int num, max_sum = -2147483648, summa = 0;
        bool flag = false;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (Math.Abs(num) % 2 == 0)
            {
                summa += num;
                flag = true;
                if (i == n - 1) max_sum = Math.Max(summa, max_sum);
            }
            else if (Math.Abs(num) % 2 != 0)
            {
                if (flag) max_sum = Math.Max(summa, max_sum);
                summa = 0;
                flag = false;
            }
        }
        if (max_sum == -2147483648 && !flag) Console.WriteLine("Нет четных элементов. Максимальная сумма подпоследовательности из четных элементов не выявлена!");
        else Console.WriteLine($"Максимальная сумма подпоследовательности из четных элементов: {max_sum}");
    }
}
