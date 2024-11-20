//Отбор в разведку

using System;

class Test
{
    static void Main()
    {
        Console.Write("Введите количество солдат: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int cnt = 0, curr_cnt = 0, even = 0, odd = 0;

        Queue<int> groups = new Queue<int>();
        groups.Enqueue(n);

        while (groups.Count > 0)
        {
            curr_cnt = groups.Dequeue(); //присваивается и удаляется из очереди
            if (curr_cnt == 3) cnt++; //если солдат трое, то прибавляем к счетчику
            else if (curr_cnt > 3) //если солдат в группе >3, продолжаем делить на чет и нечет
            {
                even = curr_cnt / 2;
                odd = curr_cnt - even;

                //добавляем в очередь
                groups.Enqueue(even);
                groups.Enqueue(odd);
            }
        }
        Console.WriteLine($"Количество групп по 3 солдата: {cnt}");
    }
}
