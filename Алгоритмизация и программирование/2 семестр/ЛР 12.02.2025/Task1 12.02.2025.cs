//Будет класс родитель, в котором будет одно поле – наименование фигуры.
//Будет интерфейс, в котором будет присутствовать два метода – вычисление площади фигуры, вычисление периметра.
//Будет 3 класса – окружность с полем радиус, реализация методов интерфейса и наследник родительского класса;
//квадрат с полем длина и реализация методов интерфейса и наследник родительского класса;
//равносторонний треугольник с полем длины и реализация методов интерфейса и наследник родительского класса.

using System;
using System.Threading;
using System.Timers;

namespace Task1
{
    class Shapes
    {
        public string Name { get; set; }

        public Shapes(string Name)
        {
            this.Name = Name;
        }
    }

    public interface ICalculation
    {
        double Area();
        double Perimeter();
    }


    class Circle: Shapes, ICalculation
    {
        public double Radius { get; set; }
        public Circle(string Name, double Radius) : base(Name)
        {
            this.Radius = Radius;
        }
        public double Area() { return Radius * Radius * Math.PI; }
        public double Perimeter() { return 2 * Radius * Math.PI; }

    }

    class Square : Shapes, ICalculation
    {
        public double Side { get; set; }
        public Square(string Name, double Side) : base(Name)
        {
            this.Side = Side;
        }
        public double Area() { return Side * Side; }
        public double Perimeter() { return 4 * Side; }

    }

    class EquilateralTriangle : Shapes, ICalculation
    {
        public double Side { get; set; }
        public EquilateralTriangle(string Name, double Side) : base(Name)
        {
            this.Side = Side;
        }
        public double Area() { return (Math.Sqrt(3) / 4) * Side * Side; }
        public double Perimeter() { return 3 * Side; }

    }


    class Programm
    {
        static void Main()
        {
            Console.Write("Введите название круга: ");
            string name_circle = Console.ReadLine();
            Console.Write($"Введите радиус круга \"{name_circle}\": ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Circle circle = new Circle(name_circle, radius);

            Console.Write("Введите название квадрата: ");
            string name_square = Console.ReadLine();
            Console.Write($"Введите длину стороны кравдрата \"{name_square}\": ");
            double side_square = Convert.ToDouble(Console.ReadLine());
            Square square = new Square(name_square, side_square);

            Console.Write("Введите название равностороннего треугольника: ");
            string name_triangle = Console.ReadLine();
            Console.Write($"Введите длину стороны равностороннего треугольника \"{name_triangle}\": ");
            double side_triangle = Convert.ToDouble(Console.ReadLine());
            EquilateralTriangle triangle = new EquilateralTriangle(name_triangle, side_triangle);

            Console.WriteLine();

            Console.WriteLine($"Наименование круга: {circle.Name}\nПлощадь: {circle.Area()}\nПериметр: {circle.Perimeter()}\n");
            Console.WriteLine($"Наименование квадрата: {square.Name}\nПлощадь: {square.Area()}\nПериметр: {square.Perimeter()}\n");
            Console.WriteLine($"Наименование равностороннего треугольника: {triangle.Name}\nПлощадь: {triangle.Area()}\nПериметр: {triangle.Perimeter()}\n");
        }
    }
}
