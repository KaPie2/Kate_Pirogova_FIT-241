//На вход подаются целые положительные числа. 
//Признак окончания последовательности – введенное отрицательное или нулевое число. 
//Необходимо каждый элемент последовательности перевернуть, удалив все нечетные цифры. 
//Если четных цифр в числе не было, выдать сообщение «Нет четных цифр». 
//Вложенные циклы while, без строк и for

using System;

class Task1
{
    static void Main()
    {
        int end_num, cnt_digit_minus_one, cnt_null = 1, new_num = 0;
        bool flag = false;
        Console.WriteLine("Введите числа. Для окончания введите ноль или отрицательное число");
        int num = Convert.ToInt32(Console.ReadLine());
        while (num > 0)
        {
            new_num = 0;
            flag = false;
            cnt_digit_minus_one = (int)Math.Log10(num); //количество разрядов - 1
            cnt_null = (int)Math.Pow(10, cnt_digit_minus_one); //10 в определенной степени для разложения числа по разрядам, начиная с наибольшего
            while (cnt_null > 0)
            {
                end_num = num % 10; //последняя цифра числа
                if (end_num % 2 == 0)
                {
                    flag = true; //есть четная цифра
                    new_num += (end_num * cnt_null);
                }
                else
                {
                    new_num /= 10; //уменьшение кол-ва разрядов числа
                }
                cnt_null /= 10; //уменьшение разряда
                num /= 10; //отсечение последней цифры числа
            }
            if (!flag)
            {
                Console.WriteLine("Нет четных цифр!");
            }
            else Console.WriteLine(new_num);
            num = Convert.ToInt32(Console.ReadLine());
        }
    }
}
