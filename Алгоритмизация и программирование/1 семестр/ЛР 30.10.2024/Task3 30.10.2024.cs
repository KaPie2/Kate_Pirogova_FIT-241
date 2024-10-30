//Поменять местами максимальный и минимальный элемент массива (мин и макс у нас один)

using System;

class Task3
{
    static void Main()
    {
        int[] num = new int[6];
        int maxi, mini, num_max = 0, num_min = 0;
        Console.WriteLine("Введите 6 целых чисел");
        for (int i = 0; i < 6; i++)
        {
            num[i] = Convert.ToInt32(Console.ReadLine());
        }
        maxi = mini = num[0];
        for (int i = 1; i < 6; i++)
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
