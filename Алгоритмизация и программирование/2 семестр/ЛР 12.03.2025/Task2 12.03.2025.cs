//Имеется класс двумя переменными целого типа, в котором реализованы 4 метода (в самом классе): +, –, * и / (проверка на ноль).
//Необходимо с использованием делегата и группировки методов с исходными данными выполнить сначала операции в следующем порядке:
//сложение двух элементов, вычитание из суммы второго элемента, умножение результата на второй элемент,
//и выполнить группу следующих операторов над исходными данными:
//умножение двух элементов, вычитание из произведения первого элемента и деление полученного результата на первый элемент.

using System;

namespace Task2
{
    class Calculate
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public Calculate(int Num1, int Num2)
        {
            this.Num1 = Num1;
            this.Num2 = Num2;
        }

        public int Summa(int x, int y) { return x + y; }
        public int Difference(int x, int y) { return x - y; }
        public int Multiplication(int x, int y) { return x * y; }
        public int Division(int x, int y) { return x / y; }

        public int FirstSequence(int x, int y)
        {
            return Multiplication(Difference(Summa(x, y), y), y);
        }

        public int SecondSequence(int x, int y)
        {
            return Division(Difference(Multiplication(x, y), x), x);
        }
    }

    class Programm
    {
        public delegate int MathOperation(int x, int y);

        static void Main()
        {
            Console.Write("Введите первое число: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Calculate calc = new Calculate(num1, num2);

            MathOperation firstSequence = calc.FirstSequence;
            MathOperation secondSequence = calc.SecondSequence;

            Console.WriteLine($"Результат первой цепочки: {firstSequence(num1, num2)}");
            if (num1 != 0)
            {
                Console.WriteLine($"Результат второй цепочки: {secondSequence(num1, num2)}");
            }
            else Console.WriteLine("Ошибка: деление на ноль невозможно!");
        }
    }
}
