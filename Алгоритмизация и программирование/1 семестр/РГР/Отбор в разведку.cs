//Отбор в разведку

using System;

class Test
{
    static int Division(int n)
    {
        if (n == 3) return 1;
        if (n < 3) return 0;

        int even = n / 2;
        int odd = n - even;
        
        return Division(even) + Division(odd);
    }
    static void Main()
    {
        Console.Write("Введите количество солдат: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Количество групп по 3 солдата: {Division(n)}");
    }
}
