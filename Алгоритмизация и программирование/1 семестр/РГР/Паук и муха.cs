//Паук и муха

using System;
using System.Diagnostics;

class Test
{
    static void Main()
    {
        double result = 0;
        Console.Write("Введите параметры комнаты через пробел: ");
        string text1 = Console.ReadLine();
        int[] room = Array.ConvertAll(text1.Split(' '), int.Parse);

        Console.Write("Введите координаты паука через пробел: ");
        string text2 = Console.ReadLine();
        int[] spider = Array.ConvertAll(text2.Split(' '), int.Parse);

        Console.Write("Введите координаты мухи через пробел: ");
        string text3 = Console.ReadLine();
        int[] fly = Array.ConvertAll(text3.Split(' '), int.Parse);

        //случай, если паук и муха в углах
        double dist = Math.Sqrt(Math.Pow(fly[0] - spider[0], 2) + Math.Pow(fly[1] - spider[1], 2) + Math.Pow(fly[2] - spider[2], 2));
        double var1 = Math.Sqrt(Math.Pow(room[0], 2) + Math.Pow(room[1], 2));
        double var2 = Math.Sqrt(Math.Pow(room[0], 2) + Math.Pow(room[2], 2));
        double var3 = Math.Sqrt(Math.Pow(room[1], 2) + Math.Pow(room[2], 2));
        if (dist == var1 || dist == var2 || dist == var3)
        {
            result = dist;
        } else
        {
            for (int i = 0; i < 3; i++)
            {
                if ((spider[i] == fly[i]) && ((fly[i] == 0) || (fly[i] == room[i]))) //на одной стене
                {
                    result = Math.Sqrt(Math.Pow(fly[0] - spider[0], 2) + Math.Pow(fly[1] - spider[1], 2) + Math.Pow(fly[2] - spider[2], 2));
                    break;
                }
                else if (((spider[i] == 0) && (fly[i] == room[i])) || ((spider[i] == room[i]) && (fly[i] == 0))) //на противоположных стенах
                {
                    //создание новых координат без координат отвечающих за расположение на разных стенах (она и есть в i относительно старых координат)
                    int[] new_s = new int[2];
                    int[] new_f = new int[2];
                    int[] new_r = new int[2];
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0)
                        {
                            new_s[j] = spider[j + 1];
                            new_f[j] = fly[j + 1];
                            new_r[j] = room[j + 1];
                        }
                        else if (i == 1)
                        {
                            if (j == 1)
                            {
                                new_s[j] = spider[j + 1];
                                new_f[j] = fly[j + 1];
                                new_r[j] = room[j + 1];
                            }
                            else
                            {
                                new_s[j] = spider[j];
                                new_f[j] = fly[j];
                                new_r[j] = room[j];
                            }
                        }
                        else
                        {
                            new_s[j] = spider[j];
                            new_f[j] = fly[j];
                            new_r[j] = room[j];
                        }
                    }
                    double m_1 = Math.Sqrt(Math.Pow(new_s[1] + room[i] + new_f[1], 2) + Math.Pow(new_s[0] - new_f[0], 2));
                    double m_2 = Math.Sqrt(Math.Pow(room[i] + (new_r[1] - new_s[1]) + (new_r[1] - new_f[1]), 2) + Math.Pow(new_s[0] - new_f[0], 2));
                    double m_3 = Math.Sqrt(Math.Pow(new_s[0] + room[i] + new_f[0], 2) + Math.Pow(new_s[1] - new_f[1], 2));
                    double m_4 = Math.Sqrt(Math.Pow(room[i] + (new_r[0] - new_s[0]) + (new_r[0] - new_f[0]), 2) + Math.Pow(new_s[1] - new_f[1], 2));
                    double temp = Math.Min(m_1, m_2);
                    double temp_1 = Math.Max(m_3, temp);
                    result = Math.Min(temp_1, m_4);
                    break;
                }
                else if ((spider[i] == room[i] && fly[i] != room[i]) || (spider[i] == 0 && fly[i] != 0) || (fly[i] == room[i] && spider[i] != room[i]) || (fly[i] == 0 && spider[i] != 0)) //на смежных стенах
                {
                    double x = 0, y = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (spider[j] != room[j] && fly[j] != room[j] && spider[j] != 0 && fly[j] != 0) x = spider[j] - fly[j];
                        else y += Math.Abs(spider[j] - fly[j]);
                    }
                    result = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                }
            }
        }
        Console.WriteLine($"Кратчайшее расстояние от паука до мухи:{result: 0.000}");
    }
}
