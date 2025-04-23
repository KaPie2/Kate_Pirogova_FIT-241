//Задание №18
//Дана волейбольная сетка с заданным количеством ячеек. 
//Определить максимальное число веревок, составляющих ее ребра, которые можно разрезать так, чтобы она не распалась.

using System;

namespace VolleyballNet
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите размеры сетки через пробел (два числа): ");
            string[] data = Console.ReadLine().Split();
            int n = Convert.ToInt32(data[0]);
            int m = Convert.ToInt32(data[1]);
            int vertexes = (n + 1) * (m + 1);

            int[,] matrix = new int[vertexes, vertexes];

            List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
            for (int i = 0; i < vertexes; i++)
            {
                for (int j = i + 1; j < vertexes; j++)
                {
                    if ((j - i == 1 && (i + 1) % (m + 1) != 0) || (j - i == m + 1))
                    {
                        matrix[i, j] = 1;
                        edges.Add(Tuple.Create(i, j));
                    }
                }
            }

            int[] components = new int[vertexes];
            for (int i = 0; i < vertexes; i++)
            {
                components[i] = i;
            }

            List<Tuple<int, int>> skeleton = new List<Tuple<int, int>>();

            foreach (var edge in edges)
            {
                int start = edge.Item1;
                int end = edge.Item2;

                if (components[start] != components[end])
                {
                    skeleton.Add(edge);
                    int max_comp = Math.Max(components[start], components[end]);
                    int min_comp = Math.Min(components[start], components[end]);

                    for (int i = 0; i < vertexes; i++)
                    {
                        if (components[i] == max_comp)
                        {
                            components[i] = min_comp;
                        }
                    }
                }
            }

            int result = edges.Count - skeleton.Count;
            Console.WriteLine($"Максимальное число веревок, которые можно разрезать так, чтобы она не распалась: {result}");
        }
    }
}
