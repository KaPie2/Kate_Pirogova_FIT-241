//1.На вход подается последовательность, состоящая из чисел, знаков математических и трех видов скобок (круглые квадратные и фигурные).
//Определить, правильно ли расставлены скобки в заданной последовательности с использованием элемента стек.
//Если скобка открывающая, то мы помещаем в стек, если закрывающая, то берем верхушку стека и проверяем.


using System;
using System.Collections;
using System.Timers;

namespace Task1
{
    class Programm
    {
        static void Main()
        {
            Console.Write("Введите последовательность: ");
            string sequence = Console.ReadLine();
            string opening_brackets = "([{";
            string closing_brackets = ")]}";
            Stack stackOfBrackets = new Stack();
            bool flag = true;
            foreach (char el in sequence)
            {
                if (opening_brackets.Contains(el)) stackOfBrackets.Push(el);
                else if (closing_brackets.Contains(el) && stackOfBrackets.Count == 0) flag = false;
                else if (closing_brackets.Contains(el) && stackOfBrackets.Count != 0)
                {
                    if ((stackOfBrackets.Peek().Equals('(') && el == ')') || (stackOfBrackets.Peek().Equals('[') && el == ']') || (stackOfBrackets.Peek().Equals('{') && el == '}'))
                    {
                        stackOfBrackets.Pop();
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag) Console.WriteLine("Скобки расставлены правильно!");
            else Console.WriteLine("Скобки расставлены неправильно!");
        }
    }
}
