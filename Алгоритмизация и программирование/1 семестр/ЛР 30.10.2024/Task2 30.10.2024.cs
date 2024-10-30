//Определить, являются ли элементы массива равномерно возрастающей последовательностью

using System;

class Task2
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] num = new int[n];
        bool flag = true;
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
        {
            num[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 2; i < n; i++)
        {
            if ((num[i] - num[i - 1] != num[i - 1] - num[i - 2]) || (num[i] == num[i - 1]))
            {
                flag = false;
                break;
            }
        }
        if (flag) Console.WriteLine("Элементы массива являются равномерно возрастающей последовательностью");
        else Console.WriteLine("Элементы массива не являются равномерно возрастающей последовательностью");
    }
}
