//Необходимо реализовать обобщенный класс, который позволяет хранить массивы заданного типа.
//В данном классе описать методы для добавления данных в массив (в конец), удаления из массива (по индексу) и получение элемента из массива (по индексу).
//Удаление, добавление и получение не с использованием методов, пишем сами. Ошибка, если индекс неправильный


using System;
using System.Numerics;
using System.Reflection;

namespace Task1
{
    public class GenArray<T>
    {
        public T[] Array { get; set; }
        public GenArray(T[] Array)
        {
            this.Array = Array;
        }

        public void Add(T elem)
        {
            Console.WriteLine($"Добавление элемента \"{elem}\"");
            T[] temp = new T[Array.Length + 1];
            for(int i = 0; i < Array.Length; i++)
            {
                temp[i] = Array[i];
            }
            temp[temp.Length - 1] = elem;
            Array = temp;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= Array.Length) Console.WriteLine("Невозможно удалить элемент: индекс введен некорректно!");
            else
            {
                Console.WriteLine($"Удаление элемента \"{Array[index]}\" по индексу {index}");
                T[] temp = new T[Array.Length - 1];
                for (int i = 0, j = 0; i < temp.Length; i++, j++)
                {
                    if (i != index) temp[j] = Array[i];
                    else
                    {
                        i++;
                        temp[j] = Array[i];
                    }
                }
                Array = temp;
            }
        }

        public void GetElem(int index)
        {
            if (index < 0 || index >= Array.Length) Console.WriteLine("Невозможно получить элемент: индекс введен некорректно!");
            else
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    if (i == index) Console.WriteLine($"Элемент массива по индексу {index}: {Array[i]}");
                }
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Данные массива: ");
            for(int i = 0;i < Array.Length;i++)
            {
                Console.WriteLine(Array[i]);
            }
        }

    }
    class Programm
    {
        static void Main()
        {
            string[] str_array = { "раз", "два", "три" };
            GenArray<string> array_1 = new GenArray<string>(str_array);
            array_1.PrintArray();

            array_1.Add("four");
            array_1.PrintArray();

            array_1.Delete(2);
            array_1.PrintArray();

            array_1.GetElem(2);

            Console.WriteLine();

            int[] int_array = { 10, 20, 30, 40 };
            GenArray<int> array_2 = new GenArray<int>(int_array);
            array_2.PrintArray();

            array_2.Add(50);
            array_2.PrintArray();

            array_2.Add(60);
            array_2.PrintArray();

            array_2.Delete(6);
            array_2.PrintArray();

            array_2.GetElem(10);

            array_2.GetElem(4);
        }
    }
}
