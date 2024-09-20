//На вход подается 2 переменные. Необходимо написать программу, которая выполняет обмен значений этих переменных. Нельзя использовать никакие дополнительные переменные.

using System;
class Task1
{
    static void Main()
    {
        Console.Write("Введите первую переменную: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите вторую переменную: ");
        int b = Convert.ToInt32(Console.ReadLine());
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine($"Первая переменная: {a}");
        Console.WriteLine($"Вторая переменная: {b}");
    }
}
