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

        public delegate int MathOperation(int x, int y);

        public int Summa(int x, int y) { return x + y; }
        public int Difference(int x, int y) { return x - y; }
        public int Multiplication(int x, int y) { return x * y; }
        public int Division(int x, int y) { return x / y; }
    }

    class Programm
    {
        static void Main()
        {
            Console.Write("Введите первое число: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            var calc1 = new Calculate(num1, num2);
            var calc2 = new Calculate(num1, num2);

            Calculate.MathOperation move1 = calc1.Summa;
            int result1 = move1(calc1.Num1, calc1.Num2); // Сложение: num1 + num2
            move1 = calc1.Difference;
            result1 = move1(result1, calc1.Num2); // Вычитание: (num1 + num2) - num2
            move1 = calc1.Multiplication;
            result1 = move1(result1, calc1.Num2); // Умножение: ((num1 + num2) - num2) * num2
            Console.WriteLine($"Результат первой цепочки: {result1}");

            Calculate.MathOperation move2 = calc2.Multiplication;
            int result2 = move2(calc2.Num1, calc2.Num2); // Умножение: num1 * num2
            move2 = calc2.Difference;
            result2 = move2(result2, calc2.Num1); // Вычитание: (num1 * num2) - num1
            move2 = calc2.Division;
            if (num1 != 0)
            {
                result2 = move2(result2, calc2.Num1); // Деление: ((num1 * num2) - num1) / num1
                Console.WriteLine($"Результат второй цепочки: {result2}");
            }
            else Console.WriteLine("Ошибка: деление на ноль невозможно!");
        }
    }
}
