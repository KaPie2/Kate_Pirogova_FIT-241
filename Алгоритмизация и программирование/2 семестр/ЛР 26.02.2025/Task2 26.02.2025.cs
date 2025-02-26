//На основе введенной польской записи вычислить результат выражения. Ввод любой.
//Если пришел знак, то из стека берем два верхних элемента, полученный результат снова в стек. На выходе в стеке одно число – результат.
//Деление на ноль невозможно!
//Пример. 3 2 + 5 * это будет 25


using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Task2
{
    class Programm
    {
        static void Main()
        {
            Console.Write("Введите польскую последовательность: ");
            var sequence = Console.ReadLine().Split(' ');
            string signs = "*+-/";
            Stack stackOfNumbers = new Stack();
            bool flag = true;
            foreach (var el in sequence)
            {
                if (flag)
                {
                    if ((signs.Contains(el) && stackOfNumbers.Count < 2)) flag = false;
                    else if (signs.Contains(el) && stackOfNumbers.Count != 0)
                    {
                        int num1 = Convert.ToInt32(stackOfNumbers.Pop());
                        int num2 = Convert.ToInt32(stackOfNumbers.Pop());
                        switch (char.Parse(el))
                        {
                            case '+':
                                stackOfNumbers.Push(num1 + num2);
                                break;
                            case '-':
                                stackOfNumbers.Push(num2 - num1);
                                break;
                            case '*':
                                stackOfNumbers.Push(num1 * num2);
                                break;
                            case '/':
                                if (num1 == 0) flag = false;
                                else stackOfNumbers.Push(num2 / num1);
                                break;
                        }
                    }
                    else stackOfNumbers.Push(Convert.ToInt32(el));
                }
                else break;
            }
            if (flag && stackOfNumbers.Count == 1) Console.WriteLine($"Результат: {stackOfNumbers.Pop()}");
            else Console.WriteLine("Последовательность задана неверно!");
        }
    }
}
