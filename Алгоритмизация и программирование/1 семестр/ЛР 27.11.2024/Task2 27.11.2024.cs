//Необходимо определить количество слов, в которых на четных местах стоят гласные буквы
using System;

class Task2
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
            bool flag = true;
            for (int j = 0; j < words[i].Length; j++)
            {
                if (("bcdfghjklmnpqrstvwxz".Contains(words[i][j])) && (j % 2 == 1))
                {
                    flag = false;
                    break;
                }
            }
            if (flag) cnt++;
        }
        Console.WriteLine($"Количество слов, в которых на четных местах стоят гласные буквы: {cnt}");
    }
}
