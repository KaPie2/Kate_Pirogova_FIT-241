//Выдать все слова, в которых присутствует хотя бы один символ «а»
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
            if (words[i].Contains('a')) Console.WriteLine(words[i]);
        }
    }
}
