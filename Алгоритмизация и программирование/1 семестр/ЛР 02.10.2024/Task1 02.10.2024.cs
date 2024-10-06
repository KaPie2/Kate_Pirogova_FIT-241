//На вход подается последовательность из n элементов (длина не менее 3х)
//Определить количество локальных максимумов (элемент, значение которого больше соседей)

using System;

class Task1
{
    static void Main()
    {
        int last_num, curr_num, next_num, cnt_local_max = 0;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        last_num = Convert.ToInt32(Console.ReadLine());
        curr_num = Convert.ToInt32(Console.ReadLine());
        for (int i = 3; i <= n; i++)
        {
            next_num = Convert.ToInt32(Console.ReadLine());
            if (curr_num > next_num && curr_num > last_num)
            {
                cnt_local_max++;
                last_num = curr_num;
                curr_num = next_num;
            } else
            {
                last_num = curr_num;
                curr_num = next_num;
            }
        }
        Console.WriteLine($"Кол-во локальных максимумов: {cnt_local_max}");
    }
}
