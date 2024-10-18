//На вход подается последовательность из n элементов (длина не менее 3х)
//Определить второй максимальный элемент

using System;

class Task3
{
    static void Main()
    {
        int curr_num, first_max, second_max;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        curr_num = Convert.ToInt32(Console.ReadLine());
        first_max = curr_num;
        curr_num = Convert.ToInt32(Console.ReadLine());
        if (curr_num > first_max)
        {
            second_max = first_max;
            first_max = curr_num;
        } else
        {
            second_max = curr_num;
        }
        for (int i = 2; i < n; i++)
        {
            curr_num = Convert.ToInt32(Console.ReadLine());
            if (curr_num > first_max)
            {
                second_max = first_max;
                first_max = curr_num;
            } else if (curr_num > second_max && curr_num <= first_max)
            {
                second_max = curr_num;
            }
        }
        // Console.WriteLine($"1-ый максимальный элемент: {first_max}");
        Console.WriteLine($"Второй максимальный элемент: {second_max}");
    }
}
