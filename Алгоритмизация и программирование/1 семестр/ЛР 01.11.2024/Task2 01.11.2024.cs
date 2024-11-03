//Необходимо отсортировать строки по убыванию количества нулевых элементов в строках. Стандартными методами сортировки пользоваться нельзя

using System;

class Task2
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int col = Convert.ToInt32(Console.ReadLine());
        int[,] arr = new int[row, col];
        int temp_null = 0, temp = 0; //вспомагательные переменные для пузырьковой сортировки
        int[] cnt_nulls = new int[row]; //массив, в который заносятся данные о кол-ве нулей в строке
        int cnt_null = 0;
        for (int i = 0; i < row; i++)
        {
            Console.WriteLine($"Введите {col} целых чисел(-ла) {i + 1}-й строки");
            for (int j = 0; j < col; j++)
            {
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (arr[i, j] == 0)
                {
                    cnt_null++;
                }
            }
            cnt_nulls[i] = cnt_null;
            cnt_null = 0;
        }
        Console.WriteLine("Исходная матрица");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < row - 1; j++)
            {
                if (cnt_nulls[j] < cnt_nulls[j + 1])
                {
                    //смена мест двух строк
                    for (int el = 0; el < col; el++)
                    {
                        temp = arr[j + 1, el];
                        arr[j + 1, el] = arr[j, el];
                        arr[j, el] = temp;
                    }
                    //смена мест в массиве, который отвечает за количество нулей в строке
                    temp_null = cnt_nulls[j + 1];
                    cnt_nulls[j + 1] = cnt_nulls[j];
                    cnt_nulls[j] = temp_null;
                }
            }
        }
        Console.WriteLine("Измененная матрица");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
