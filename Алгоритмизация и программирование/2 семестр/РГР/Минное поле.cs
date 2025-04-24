//Минное поле

using System;
using System.Collections.Generic;

namespace Minefield
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите размер минного поля через пробел: ");
            string[] data = Console.ReadLine().Trim().Split();
            int n = Convert.ToInt32(data[0]);
            int m = Convert.ToInt32(data[1]);

            int[,] mines = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите {m} мин через пробел для {i + 1} ряда: ");
                string[] row = Console.ReadLine().Trim().Split();
                for (int j = 0; j < m; j++)
                {
                    mines[i, j] = Convert.ToInt32(row[j]);
                }
            }

            int[,] min_time = new int[n, m];
            int[,] way = new int[n, m];

            for (int j = 0; j < m; j++)
            {
                min_time[0, j] = mines[0, j];
                way[0, j] = -1; // нет предка для первой строки
            }

            for (int row = 1; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    int min_curr = min_time[row - 1, col];
                    int prev_col = col;

                    if (col - 1 >= 0 && min_time[row - 1, col - 1] < min_curr)
                    {
                        min_curr = min_time[row - 1, col - 1];
                        prev_col = col - 1;
                    }

                    if (col + 1 < m && min_time[row - 1, col + 1] < min_curr)
                    {
                        min_curr = min_time[row - 1, col + 1];
                        prev_col = col + 1;
                    }

                    min_time[row, col] = mines[row, col] + min_curr;
                    way[row, col] = prev_col;
                }
            }

            int min_total = min_time[n - 1, 0];
            int min_col = 0;

            for (int j = 1; j < m; j++)
            {
                if (min_time[n - 1, j] < min_total)
                {
                    min_total = min_time[n - 1, j];
                    min_col = j;
                }
            }

            // Восстанавливаем путь
            List<int> result = new List<int>();
            int curr_col = min_col;

            for (int i = n - 1; i >= 0; i--)
            {
                result.Add(curr_col + 1);
                curr_col = way[i, curr_col];
            }
            result.Reverse();

            Console.WriteLine("Оптимальный путь:");
            foreach (int col in result)
            {
                Console.WriteLine(col);
            }
        }
    }
}
