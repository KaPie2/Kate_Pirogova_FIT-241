//Есть начальная точка, с которой начинаем (старт), есть конечная точка (финиш).
//Три объекта класса участник, которые характеризуются именем, начальной скоростью.
//Через заданный интервал времени (сами) случайным образом происходит смена скорости у каждого участника,
//приращения расстояния, который прошел участник зависит от скорости и интервала.
//Обработать события выхода одного из участников за пределы финиша (победа участника), если несколько, то победа двоих.

using System;

namespace Task1
{
    public class Player
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public Player(string Name, int Speed)
        {
            this.Name = Name;
            this.Speed = Speed;
            Distance = 0;
        }
    }

    public delegate void FinishEventHandler(string message);
    public class UpdateSpeed
    {
        public Player pl_1, pl_2, pl_3;
        public int Interval { get; set; }
        public int DistRace { get; set; }
        public Random rdm = new Random();

        // событие завершение гонки
        public event FinishEventHandler FinishEvent;

        public UpdateSpeed(int Interval, Player pl_1, Player pl_2, Player pl_3, int DistRace)
        {
            this.Interval = Interval;
            this.pl_1 = pl_1;
            this.pl_2 = pl_2;
            this.pl_3 = pl_3;
            this.DistRace = DistRace;
        }

        public void SpeedRdm()
        {
            Random rdm = new Random();

            // вычисление пройденного расстояния
            pl_1.Distance += Interval * pl_1.Speed;
            pl_2.Distance += Interval * pl_2.Speed;
            pl_3.Distance += Interval * pl_3.Speed;

            int max_dist = Math.Max(pl_1.Distance, pl_2.Distance);
            max_dist = Math.Max(max_dist, pl_3.Distance);
            if (max_dist > DistRace)
            {
                foreach (var player in new[] { pl_1, pl_2, pl_3 })
                {
                    if (player.Distance > DistRace)
                    {
                        if (FinishEvent != null)
                        {
                            FinishEvent($"{player.Name} завершил гонку!");
                        }
                    }
                }
            } else
            {
                pl_1.Speed = rdm.Next(1, 100);
                pl_2.Speed = rdm.Next(1, 100);
                pl_3.Speed = rdm.Next(1, 100);
            }
        }
    }
    class Programm
    {
        static void Main()
        {
            Player pl_1, pl_2, pl_3;
            int distance = 100; // метров
            bool flag = false;

            Console.Write("Введите имя и начальную скорость (м/мин) первого участника через пробел: ");
            string[] data = Console.ReadLine().Split(' ');
            pl_1 = new Player(data[0], Convert.ToInt32(data[1]));
            Console.Write("Введите имя и начальную скорость (м/мин) второго участника через пробел: ");
            data = Console.ReadLine().Split(' ');
            pl_2 = new Player(data[0], Convert.ToInt32(data[1]));
            Console.Write("Введите имя и начальную скорость (м/мин) третьего участника через пробел: ");
            data = Console.ReadLine().Split(' ');
            pl_3 = new Player(data[0], Convert.ToInt32(data[1]));

            UpdateSpeed updater = new UpdateSpeed(1, pl_1, pl_2, pl_3, distance); // интервал 1 минута

            updater.FinishEvent += message =>
            {
                Console.WriteLine(message);
                flag = true;
            };

            // изменение скорости
            while (!flag)
            {
                updater.SpeedRdm();
            }
        }
    }
}
