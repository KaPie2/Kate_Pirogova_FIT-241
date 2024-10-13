//Дана последовательность из n элементов (массивы не знаем)
//Минимальную длину подпоследовательности из единичек

using System;

class Task2
{
    static void Main()
    {
        int num, cnt = 0, cnt_min;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        cnt_min = n + 1;
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                cnt++;
            }
            else
            {
                if (cnt > 0) cnt_min = Math.Min(cnt, cnt_min);
                cnt = 0;
            }
        }
        if (cnt > 0) cnt_min = Math.Min(cnt, cnt_min);
        if (cnt_min == n + 1) cnt_min = 0;
        Console.WriteLine($"Минимальная длина из единиц: {cnt_min}");
    }
}
