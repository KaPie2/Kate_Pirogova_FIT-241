//На вход подается строка, состоящая из заглавных букв латинского алфавита. 
//Необходимо определить максимальную длину подстроки, состоящую из последовательности элементов xyz (в данном порядке), 
//при этом допускается неполная комбинация в конце (xy или x). Выдать длину

using System;

class Task1
{
    static void Main()
    {
        int cnt = 0, max_len = 0;
        Console.WriteLine("Введите строку:");
        string data = Console.ReadLine();
        for (int i = 0; i < data.Length - 1; i++)
        {
            if (data[i] == 'X' && cnt == 0) cnt++;
            if (((data[i] == 'X' && data[i + 1] == 'Y') || (data[i] == 'Y' && data[i + 1] == 'Z') || (data[i] == 'Z' && data[i + 1] == 'X')) && cnt != 0) cnt++;
            if (((data[i] == 'X' && data[i + 1] != 'Y') || (data[i] == 'Y' && data[i + 1] != 'Z') || (data[i] == 'Z' && data[i + 1] != 'X')) && cnt != 0)
            {
                max_len = Math.Max(max_len, cnt);
                cnt = 0;
            };
            max_len = Math.Max(max_len, cnt);
        }
        Console.WriteLine($"Максимальная длина подстроки XYZ: {max_len}");
    }
}
