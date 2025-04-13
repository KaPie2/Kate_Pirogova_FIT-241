//Необходимо реализовать обобщенный класс, в котором присутствует две переменные.
//Для этих переменных реализовать: сложение, вычитание, умножение и деление.

using System;

namespace Task2
{
    public class Calculator<T>
    {
        public T Num1 { get; set; }
        public T Num2 { get; set; }
        public Calculator(T Num1, T Num2)
        {
            this.Num1 = Num1;
            this.Num2 = Num2;
        }
        public void Summa()
        {
            dynamic x = Num1;
            dynamic y = Num2;
            Console.WriteLine($"Сумма: {x + y}");
        }
        public void Difference()
        {
            dynamic x = Num1;
            dynamic y = Num2;
            Console.WriteLine($"Разность: {x - y}"); 
        }
        public void Multiplication()
        {
            dynamic x = Num1;
            dynamic y = Num2;
            Console.WriteLine($"Умножение: {x * y}");
        }
        public void Division()
        {
            dynamic x = Num1;
            dynamic y = Num2;
            if (y == 0) Console.WriteLine("Делить на ноль нельзя!\n");
            else Console.WriteLine($"Деление: {x / y}\n");
        }
    }
    class Programm
    {
        static void Main()
        {
            Calculator<int> int_data = new Calculator<int>(3, 10);
            int_data.Summa();
            int_data.Difference();
            int_data.Multiplication();
            int_data.Division();

            Calculator<double> double_data = new Calculator<double>(0.3, 0.7829);
            double_data.Summa();
            double_data.Difference();
            double_data.Multiplication( );
            double_data.Division();

            Calculator<uint> uint_data = new Calculator<uint>(45, 0);
            uint_data.Summa();
            uint_data.Difference();
            uint_data.Multiplication();
            uint_data.Division();
        }
    }
}
