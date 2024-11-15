//Необходимо создать массив, состоящий из n одномерных массивов разной длины. 
//Заполнение каждого одномерного массива выполнить с помощью функции. 
//В каждом одномерном массиве определить максимальный и минимальный элемент, не используя функции максимума и минимума

using System;

class Task1
{
    static int[] FillNum(int l)
    {
        int[] arr = new int[l];
        Console.WriteLine($"Введите {l} целых чисел");
        for (int i = 0; i < l; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        return arr;
    }
    static void Main()
    {
        int maxi = 0, mini = 0; //задаем значения, чтобы при проверке машина не ругалась. В последнем вложенном цикле эти значения присваиваются заново
        Console.Write("Введите количество одномерных массивов зубчатого массива: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] num = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите количество элементов для {i + 1}-ого одномерного массива: ");
            int l = Convert.ToInt32(Console.ReadLine());
            num[i] = FillNum(l);
        }
        Console.WriteLine("Исходная матрица");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < num[i].Length; j++)
            {
                Console.Write(num[i][j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0;i < n; i++)
        {
            for (int j = 0; j < num[i].Length; j++)
            {
                if (j == 0)
                {
                    maxi = num[i][j];
                    mini = num[i][j];
                }
                else
                {
                    if (maxi < num[i][j]) maxi = num[i][j];
                    if (mini > num[i][j]) mini = num[i][j];
                }
            }
            Console.WriteLine($"Максимум {i + 1}-ого одномерного массива: {maxi}");
            Console.WriteLine($"Минимум {i + 1}-ого одномерного массива: {mini}");
            Console.WriteLine();
        }
    }
}
