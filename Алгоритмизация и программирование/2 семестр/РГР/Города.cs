//Города

using System;

namespace Towns
{
    class Programm
    {

        static void Main()
        {
            int towns, roads, start, end, weight;
            int max_road = int.MinValue;
            Console.Write("Введите количество городов и дорог через пробел: ");
            string[] data = Console.ReadLine().Split(' ');
            towns = Convert.ToInt32(data[0]);
            roads = Convert.ToInt32(data[1]);

            // создание шаблонной матрицы смежности
            int[,] main_matrix = new int[towns, towns];
            for (int i = 0; i < towns; i++)
            {
                for (int j = 0; j < towns; j++)
                {
                    if (i == j) main_matrix[i, j] = 0;
                    else main_matrix[i, j] = 1001; // по условию длина дороги <= 1000
                }
            }

            // заполнение матрицы смежности
            for (int i = 0; i < roads; i++)
            {
                Console.Write("Введите три числа через пробел (номера городов, соединенных дорогой и длина дороги): ");
                data = Console.ReadLine().Split(' ');
                start = Convert.ToInt32(data[0]) - 1; // -1 из-за индекса
                end = Convert.ToInt32(data[1]) - 1;
                weight = Convert.ToInt32(data[2]);

                main_matrix[start, end] = Math.Min(weight, main_matrix[start, end]);
                main_matrix[end, start] = Math.Min(weight, main_matrix[end, start]);
            }

            // алгоритм флойда
            int[,] new_matrix = (int[,])main_matrix.Clone();
            for (int k = 0; k < towns; k++)
            {
                new_matrix = (int[,])main_matrix.Clone();
                for (int i = 0; i < towns; i++)
                {
                    for (int j = 0; j < towns; j++)
                    {
                        new_matrix[i, j] = Math.Min(main_matrix[i, k] + main_matrix[k, j], main_matrix[i, j]);
                    }
                }
                main_matrix = (int[,])new_matrix.Clone();
            }

            for (int i = 0; i < towns; i++)
            {
                for (int j = 0; j < towns; j++)
                {
                    max_road = Math.Max(new_matrix[i, j], max_road);
                }
            }

            Console.WriteLine($"Наибольшее расстояние между городами в стране: {max_road}");
        }
    }
}
