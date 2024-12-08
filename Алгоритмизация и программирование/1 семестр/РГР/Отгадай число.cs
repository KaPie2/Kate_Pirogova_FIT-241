//Отгадай число
using System;
class Test
{
    static void Main()
    {
        Console.Write("Введите количество действий: ");
        int n = Convert.ToInt32(Console.ReadLine());
        char[] moves = new char[n];
        string[] num = new string[n];
        Console.WriteLine($"Введите {n} действий в формате S V, где S - тип действия (*, +, -), V - число, например \"* 4\" или \"- х\", где х (с английской раскладки) - неизвестное число");
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            moves[i] = char.Parse(s.Substring(0, 1));
            num[i] = s.Substring(2, s.Length - 2);
        }
        Console.Write("Введите результат: ");
        int r = Convert.ToInt32(Console.ReadLine());
        for (int x = -100; x < 101; x++)
        {
            int res = x;
            for (int i = 0; i < n; i++)
            {
                if (num[i] == "x")
                {
                    if (moves[i] == '+') res += x;
                    else res -= x;
                }
                else
                {
                    switch (moves[i])
                    {
                        case '+':
                            res += Convert.ToInt32(num[i]);
                            break;
                        case '*':
                            res *= Convert.ToInt32(num[i]);
                            break;
                        case '-':
                            res -= Convert.ToInt32(num[i]);
                            break;
                    }
                }
            }
            if (res == r)
            {
                Console.WriteLine($"Загаданное число: {x}");
                break;
            }
        }
    }
}
