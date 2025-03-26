//Есть класс точка с координатами x, y (целые).
//Есть класс события, который обрабатывает ситуацию выхода точки в результате движения за границы заданной области (достаточно сообщения).
//Область задается правильным прямоугольником. Задавать будем либо 4 точками, либо двумя.
//Точка изначально инициализируется внутри заданной области.
//Движение определяется рандомным (рандом) показателем по x, y наращением.
//Предусмотреть возможность хождения назад.

using System;

namespace Task1
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void Move(int deltaX, int deltaY)
        {
            Console.WriteLine("Точка перемещается");
            X += deltaX;
            Y += deltaY;
        }
    }
    public delegate void OutEventHandler(string message);
    public class PointMover
    {
        public Point point, p1, p2;
        public Random rdm = new Random();

        // Событие выхода за границы
        public event OutEventHandler OutEvent;

        public PointMover(Point point, Point p1, Point p2)
        {
            this.point = point;
            this.p1 = p1;
            this.p2 = p2;
        }

        public void MoveRdm()
        {
            int deltaX = rdm.Next(-100, 101);
            int deltaY = rdm.Next(-100, 101);

            point.Move(deltaX, deltaY);

            if (point.X < p1.X || point.X > p2.X || point.Y < p1.Y || point.Y > p2.Y)
            {
                if (OutEvent != null)
                {
                    OutEvent("Точка вышла за границы");
                }
            }
        }
    }
    class Programm
    {
        static void Main()
        {
            Point point_rectangle_1, point_rectangle_2, point;
            bool flag = false;
            Console.Write("Введите координаты левого нижнего угла прямоугольника (два числа через пробел): ");
            string[] data = Console.ReadLine().Split(' ');
            point_rectangle_1 = new Point(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
            Console.Write("Введите координаты правого верхнего угла прямоугольника(два числа через пробел): ");
            data = Console.ReadLine().Split(' ');
            point_rectangle_2 = new Point(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));

            point = new Point((point_rectangle_2.X + point_rectangle_1.X) / 2, (point_rectangle_2.Y + point_rectangle_1.Y) / 2); // точка в середине прямоугольника

            PointMover mover = new PointMover(point, point_rectangle_1, point_rectangle_2);
            mover.OutEvent += message =>
            {
                Console.WriteLine(message);
                flag = true;
            };

            // перемещения
            while (!flag)
            {
                mover.MoveRdm();
                Console.WriteLine($"Текущая позиция: ({point.X}, {point.Y})");
            }
        }
    }
}
