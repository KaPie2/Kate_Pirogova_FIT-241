//N штук грядок. У каждой есть ширина и высота. Имеется колодец и расстояние от него. Определить путь, который мы пройдем при поливе всех грядок (проходим по периметру грядки и возвращаемся в колодец). Без цикла for.

using System;
class Task3
{
    static void Main()
    {
        Console.Write("Введите L (ширину грядки): ");
        int l = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите M (длину грядки): ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите P (расстояние от колодца до первой грядки): ");
        int p = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите N (количество грядок): ");
        int n = Convert.ToInt32(Console.ReadLine());
        int answer = 2 * n * p + 2 * n * (l + m) + n * (n - 1) * l;
        Console.WriteLine($"Ответ: {answer}");
    }
}
