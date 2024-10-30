//Определить, являются ли элементы массива равномерно возрастающей последовательностью

using System;

class Task2
{
    static void Main()
    {
        int[] num = new int[6];
        bool flag = true;
        Console.WriteLine("Введите 6 целых чисел");
        for (int i = 0; i < 6; i++)
        {
            num[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 2; i < 6; i++)
        {
            if (num[i] - num[i - 1] != num[i - 1] - num[i - 2])
            {
                flag = false;
                break;
            }
        }
        if (flag) Console.WriteLine($"Элементы массива являются равномерно возрастающей последовательностью");
        else Console.WriteLine($"Элементы массива не являются равномерно возрастающей последовательностью");
    }
}
