//Поменять местами максимальный и минимальный элемент массива (мин и макс у нас один)

using System;

class Task3
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] num = new int[n];
        int maxi, mini, num_max = 0, num_min = 0;
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
        {
            num[i] = Convert.ToInt32(Console.ReadLine());
        }
        maxi = mini = num[0];
        for (int i = 1; i < n; i++)
        {
            if (num[i] > maxi)
            {
                maxi = num[i];
                num_max = i;
            }
            else if (num[i] < mini)
            {
                mini = num[i];
                num_min = i;
            }
        }
        num[num_max] = mini;
        num[num_min] = maxi;
        Console.WriteLine("Максимум и минимум поменялись местами");
        foreach (int el in num)
        {
            Console.WriteLine(el);
        }
    }
}
