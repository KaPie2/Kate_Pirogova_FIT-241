//На вход подается 2 переменные. Необходимо написать программу, которая выполняет обмен значений этих переменных. Нельзя использовать никакие дополнительные переменные.

using System;
public class Task1
{
    public static void Main()
    {
        Console.Write("enter the first variable: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("enter the second variable: ");
        int b = Convert.ToInt32(Console.ReadLine());
        (a, b) = (b, a);
        Console.WriteLine($"the first variable: {a}");
        Console.WriteLine($"the second variable: {b}");
    }
}
