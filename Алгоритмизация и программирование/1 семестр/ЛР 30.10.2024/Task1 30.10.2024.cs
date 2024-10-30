//Определить кол-во элементов оканчивающихся на 3

using System;

class Task1
{
    static void Main()
    {
        int[] num = new int[6];
        int cnt = 0;
        Console.WriteLine("Введите 6 целых чисел");
        for (int i = 0; i < 6; i++)
        {
            num[i] = Convert.ToInt32(Console.ReadLine());
        }
        foreach(int el in num)
        {
            if (Math.Abs(el) % 10 == 3)
            {
                cnt++;
            }
        }
        Console.WriteLine($"Количество чисел заканчивающихся на 3: {cnt}");
    }
}
