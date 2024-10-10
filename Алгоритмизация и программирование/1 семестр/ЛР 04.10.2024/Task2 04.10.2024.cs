//Дана последовательность из n элементов (массивы не знаем)
//Минимальную длину подпоследовательности из единичек


using System;

class Task1
{
    static void Main()
    {
        int last_num, curr_num, cnt = 0, cnt_min = 0;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        last_num = Convert.ToInt32(Console.ReadLine());
        if (last_num == 1)
        {
            cnt++;
        }
        for (int i = 1; i < n; i++)
        {
            curr_num = Convert.ToInt32(Console.ReadLine());
            if (curr_num == 1)
            {
                cnt++;
            } else if (last_num == 1 && curr_num != 1 && cnt_min == 0)
            {
                cnt_min = cnt;
                cnt = 0;
            } else if (last_num == 1 && curr_num != 1 && cnt != 0)
            {
                cnt_min = Math.Min(cnt, cnt_min);
                cnt = 0;
            }
            last_num = curr_num;
        }
        Console.WriteLine($"Минимальная длина из единиц: {cnt_min}");
    }
}
