//На вход подается последовательность из n элементов (длина не менее 3х)
//Определить все ли элементы нечетные

using System;

class Task2
{
	static void Main()
	{
		int num;
		bool flag = true;
		Console.Write("Введите количество элементов: ");
		int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Введите {n} целых чисел");
        for (int i = 0; i < n; i++)
		{
            num = Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0)
			{
				flag = false; 
			}
		}
		if (flag)
		{
			Console.WriteLine("Все числа нечетные!");
		} else
		{
			Console.WriteLine("Есть четное число!");

        }
	}
}
