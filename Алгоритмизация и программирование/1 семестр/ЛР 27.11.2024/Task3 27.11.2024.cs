//Определить количество слов, длина которых нечетная, а первый и последний символ совпадают
using System;

class Task3
{
    static void Main()
    {
        int cnt = 0;
        Console.WriteLine("Введите строку:");
        string data = Console.ReadLine().ToLower();
        while (data.Contains("  "))
        {
            data = data.Replace("  ", " ");
        }
        string[] words = data.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if ((words[i].Length % 2 == 1) && (words[i][0].Equals(words[i][^1]))) cnt++;
        }
        Console.WriteLine($"Количество слов, длина которых нечетная, а первый и последний символ совпадают: {cnt}");
    }
}
