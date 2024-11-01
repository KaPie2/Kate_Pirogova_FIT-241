//Необходимо в массиве поменять местами максимальный и минимальный элемент массива (макс и мин один)

using System;

class Task3
{
    static void Main()
    {
        int maxi, mini, row_max = 0, row_min = 0, col_max = 0, col_min = 0;
        Console.Write("Введите количество строк: ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int col = Convert.ToInt32(Console.ReadLine());
        int[,] num = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            Console.WriteLine($"Введите {col} целых чисел(-ла) {i + 1}-й строки");
            for (int j = 0; j < col; j++)
            {
                num[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        maxi = mini = num[0, 0];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (num[i, j] > maxi)
                {
                    maxi = num[i, j];
                    row_max = i;
                    col_max = j;
                }
                else if (num[i, j] < mini)
                {
                    mini = num[i, j];
                    row_min = i;
                    col_min = j;
                }
            }
        }
        Console.WriteLine("Исходная матрица");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(num[i, j] + "\t");
            }
            Console.WriteLine();
        }
        num[row_min, col_min] = maxi;
        num[row_max, col_max] = mini;
        Console.WriteLine("Максимум и минимум поменялись местами");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(num[i, j] + "\t");
            }
            Console.WriteLine();
        }


    }
}
