//Дана строка, состоящая из латинских букв любого регистра.
//Необходимо определить символ, который реже всего встречается в образце a*b, где * - искомый символ (символ обязательно должен присутствовать),
//если символов несколько, то выдать все

using System;
using System.Runtime.Intrinsics.X86;
using System.Timers;

class Task2
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string data = Console.ReadLine().ToLower();
        string res_el = ""; //для добавления искомых элементов
        int min_cnt_el = data.Length + 1;
        bool flag = false;
        for (int i = 2; i < data.Length; i++)
        {
            int cnt = 0;
            flag = false;
            if (data[i - 2] == 'a' && data[i] == 'b')
            {
                for (int j = 0; j < data.Length - 2; j++)
                {
                    string substr = data.Substring(j, 3); //каждая подстрока (тройка) строки
                    string temp = data.Substring(i - 2, 3); //подстрока вида a*b
                    if (substr.Contains(temp))
                    {
                        cnt++;
                        flag = true;
                    }
                }
            }
            if (cnt < min_cnt_el && flag)
            {
                res_el = "";
                min_cnt_el = cnt;
                res_el += data[i - 1];
            }
            else if (cnt == min_cnt_el && !(res_el.Contains(data[i - 1]))) res_el += data[i - 1];
        }
        if (flag)
        {
            Console.WriteLine($"Символ(-ы), который(-ые) реже всего встречается(-ются) в образце a*b:");
            foreach (char el in res_el)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            Console.WriteLine($"Встречается(-ются) {min_cnt_el} раз(-а)");
        }
        else Console.WriteLine("Cимвол, который встречается в образце a*b, не обнаружен");
    }
}
