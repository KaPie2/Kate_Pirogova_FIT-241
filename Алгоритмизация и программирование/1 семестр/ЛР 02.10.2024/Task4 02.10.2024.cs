//На вход подается последовательность из n элементов (длина не менее 3х)
//Определить количество элементов, оканчивающихся на 5 (и положительные, и отрицательные)

using System;

class Task3
{
	static void Main()
	{
        int num, cnt = 0;
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (Math.Abs(num) % 10 == 5)
            {
                cnt++;
            }
        }
        Console.WriteLine($"Кол-во элементов, оканчивающихся на 5: {cnt}");
    }
}
