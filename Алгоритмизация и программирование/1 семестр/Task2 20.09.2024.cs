//Переменные целого типа. Из двух вводимых переменных выдать наибольшее и наименьшее значение. Нельзя использовать сравнения, встроенные функции, конструкция if.

using System;
class Task2
{
    static void Main()
    {
        Console.Write("Введите первую переменную: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите вторую переменную: ");
        int b = Convert.ToInt32(Console.ReadLine());
        int maximum = (a + b + Math.Abs(a - b)) / 2;
        int minimum = (a + b - Math.Abs(a - b)) / 2;
        Console.WriteLine($"Максимум: {maximum}");
        Console.WriteLine($"Минимум: {minimum}");
    }
}
