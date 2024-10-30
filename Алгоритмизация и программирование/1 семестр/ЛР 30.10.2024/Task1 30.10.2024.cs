//Определить кол-во элементов, оканчивающихся на 3

using System;

class Task1
    {
        static void Main()
        {
            Console.Write("Введите количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[n];
            int cnt = 0;
            Console.WriteLine($"Введите {n} целых чисел");
            for (int i = 0; i < n; i++)
            {
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            foreach (int el in num)
            {
                if (Math.Abs(el) % 10 == 3)
                {
                    cnt++;
                }
            }
            Console.WriteLine($"Количество чисел, заканчивающихся на 3: {cnt}");
        }
    }
