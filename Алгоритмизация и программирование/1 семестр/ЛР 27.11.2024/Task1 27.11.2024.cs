//Необходимо отформатировать строку таким образом, чтобы между словами было по одному пробелу
using System;

class Task1
{
    static void Main()
    {

        Console.WriteLine("Введите строку:");
        string data = Console.ReadLine();
        while (data.Contains("  "))
        {
            data = data.Replace("  ", " ");
        }
        Console.WriteLine("Итог:");
        Console.WriteLine(data);
    }
}
