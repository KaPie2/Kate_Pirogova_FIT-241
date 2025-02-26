//Дан список элементов (лист) целого типа. Необходимо:
//Определить, с помощью каких элементов составлен список
//Какой элемент чаще всего присутствует в списке (если таких несколько, то выдать все)


using System;
using System.Timers;

namespace Task3
{
    class Programm
    {
        static void Main()
        {

            HashSet<int> setOfNumbers = new HashSet<int>();
            Dictionary<int, int> cnt = new Dictionary<int, int>();

            Console.Write("Введите количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов:");
            for (int i = 0; i < n; i++)
            {
                int el = Convert.ToInt32(Console.ReadLine());
                setOfNumbers.Add(el);
                if (cnt.ContainsKey(el)) cnt[el] += 1;
                else cnt.Add(el, 1);
            }

            Console.WriteLine("Множество состоит из следующих элементов: ");
            foreach (int el in setOfNumbers)
            { 
                Console.WriteLine(el);
            }


            int maximum = cnt.Values.Max();
            Console.WriteLine("Элемент, который чаще всего встречается в списке: ");
            foreach (int el in setOfNumbers)
            {
                if (cnt[el] == maximum) Console.WriteLine(el);
            }
        }
    }
}
