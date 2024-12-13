//Дан класс, состоящий из двух полей целого типа. Необходимо реализовать в классе 3 конструктора:
//•	без параметров (все поля инициализируются нулями)
//•	с одним параметром (второе поле инициализируется нулем)
//•	с двумя параметрами (поля инициализируются заданными значениями)
//Создать 4 метода, которые реализуют сложение двух элементов, разность первого со вторым,
//произведение двух элементов и деление первого на второй (при делении отловить ошибку деления на ноль).
//В головной программе создать объекты с использованием каждого конструктора и для каждого объекта выполнить все 4 метода.
//Выдать результаты (можно в методе или в main)

using System;
using System.Collections.Specialized;

namespace Task1
{
    class Calc
    {
        public float Num1 { get; set; }
        public float Num2 { get; set; }

        public Calc()
        {
            Num1 = 0;
            Num2 = 0;
        }

        public Calc(float Num1)
        {
            this.Num1 = Num1;
            Num2 = 0;
        }

        public Calc(float Num1, float Num2)
        {
            this.Num1 = Num1;
            this.Num2 = Num2;
        }

        public void Summa() => Console.WriteLine($"Результат суммы: {Num1 + Num2}");

        public void Difference() => Console.WriteLine($"Результат разности: {Num1 - Num2}");

        public void Product() => Console.WriteLine($"Результат произведения: {Num1 * Num2}");

        public void Division()
        {
            if (Num2 == 0) Console.WriteLine("Результат деления: делить на 0 нельзя!");
            else Console.WriteLine($"Результат деления: {Num1 / Num2}");
        }
    }

    class Programm
    {
        static void Main()
        {
            float a = 24;
            float b = 6;

            Calc move1 = new Calc();
            move1.Summa();
            move1.Difference();
            move1.Product();
            move1.Division();
            Console.WriteLine();

            Calc move2 = new Calc(a);
            move2.Summa();
            move2.Difference();
            move2.Product();
            move2.Division();
            Console.WriteLine();

            Calc move3 = new Calc(a, b);
            move3.Summa();
            move3.Difference();
            move3.Product();
            move3.Division();
        }
    }
}
