//Дана последовательность из n элементов (массивы не знаем). 
//Необходимо определить максимальную длину подпоследовательности из одинаковых четных элементов.


using System;

class Task1
{
    static void Main()
    {
        int last_num, curr_num, cnt = 0, cnt_max = 0;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        last_num = Convert.ToInt32(Console.ReadLine());
        if (last_num % 2  == 0 )
        {
            cnt++;
        }
        cnt_max = Math.Max(cnt, cnt_max);
        for (int i = 1; i < n; i++)
        {
            curr_num = Convert.ToInt32(Console.ReadLine());
            if (curr_num % 2 == 0 && last_num % 2 != 0)
            {
                cnt = 1;
            } else if (curr_num == last_num && curr_num % 2 == 0)
            {
                cnt++;
            } else
            {
                cnt = 0;
            }
            cnt_max = Math.Max(cnt, cnt_max);
            last_num = curr_num;
        }
        Console.WriteLine($"Максимальная длина из одинаковых четных элементов: {cnt_max}");
    }
}
