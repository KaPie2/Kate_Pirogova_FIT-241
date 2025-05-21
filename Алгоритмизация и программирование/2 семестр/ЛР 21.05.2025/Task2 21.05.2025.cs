//Необходимо сформировать массив, заданной длины (либо сами, либо считывать), и из массива выдать только числовые значения, являющиеся палиндромом.
//Работаем с указателями (указатель на массив), массив int, выделять память через tcolloc, foreach нельзя

using System;

namespace Task2
{
    class Programm
    {
        unsafe static void Main()
        {
            int* array = stackalloc int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите {i + 1}-й элемент: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 5; i++)
            {
                int reversed = 0;
                int num = array[i];
                int original = num;

                while (num > 0)
                {
                    reversed = reversed * 10 + num % 10;
                    num /= 10;
                }

                if (original == reversed) Console.WriteLine($"Число {original} — палиндром");
            }
        }
    }
}
