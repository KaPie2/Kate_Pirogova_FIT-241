//Необходимо определить пары номеров столбцов, состоящих из одинаковых элементов

using System;

class Task1
{
    static void Main()
    {
        int summa = 0, multiplication = 1, cnt_null = 0;
        bool flag = false;
        Console.Write("Введите количество строк: ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int col = Convert.ToInt32(Console.ReadLine());
        int[,] num = new int[row, col];
        int[,] res = new int[col, 4]; //результаты каждого столбца заносятся по типу {сумма элементов, произведение, количество нулей, номер}
        for (int i = 0; i < row; i++)
        {
            Console.WriteLine($"Введите {col} целых чисел(-ла) {i + 1}-й строки");
            for (int j = 0; j < col; j++)
            {
                num[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (num[j, i] == 0)
                {
                    cnt_null++;
                }
                summa += num[j, i];
                multiplication *= num[j, i];
            }
            res[i, 0] = summa;
            res[i, 1] = multiplication;
            res[i, 2] = cnt_null;
            res[i, 3] = i + 1;
            summa = 0;
            multiplication = 1;
            cnt_null = 0;
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
        for (int i = 0; i < col - 1; i++)
        {
            for (int j = i + 1;j < col; j++)
            {
                if ((res[i, 0] == res[j, 0]) && (res[i, 1] == res[j, 1]) && (res[i, 2] == res[j, 2]))
                {
                    Console.WriteLine($"Столбцы {res[i, 3]} и {res[j, 3]} имеют одинаковые элементы");
                    flag = true;
                }
            }
        }
        if (!flag) Console.WriteLine("В матрице нет пар столбцов с одинаковыми элементами");
        //Проверка матрицы результатов столбцов

        //for (int i = 0; i < col; i++)
        //{
        //    for (int j = 0; j < 4; j++)
        //    {
        //        Console.Write(res[i, j] + "\t");
        //    }
        //    Console.WriteLine();
        //}
    }
}
