using System;

namespace Лабораторная_работа_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Вариант 10\n");
            do
            {
                Console.WriteLine("\n\tМЕНЮ\n");
                Console.Write(@"1) Задача 1
2) Задача 2
3) Задача 3
4) Выход
 = ");
                number = (int)Get_double();
                switch (number)
                {
                case 1:
                        task_1();
                        break;
                case 2:
                        task_2();
                        break;
                case 3:
                        task_3();
                        break;
                case 4:
                        break;
                }
            }
            while (number != 4);
        }
        static double Get_double()
        {
            double x;
            string buf;
            bool correct;
            do
            {
                buf = Console.ReadLine();
                correct = double.TryParse(buf, out x);
                if (!correct)
                    Console.Write("Ошибка! Введите ещё раз.\n= ");
            }
            while (!correct);
            return x;
        }
        static void task_1()
        {
            Console.WriteLine("Задача 1\n");
            int r1;
            double r4;
            bool r2, r3;
            Console.Write("m = ");
            int m = (int)Get_double();
            Console.Write("n = ");
            int n = (int)Get_double();
            r1 = m / --n; n++;
            Console.WriteLine("1) m=" + m + " n=" + n + " m/--n++ = " + r1);
            r2 = m / n < n--;
            Console.WriteLine("2) m=" + m + " n=" + n + " m/n<n-- = " + r2);
            r3 = m + n++ > n + m;
            Console.WriteLine("3) m=" + m + " n=" + n + " m+n++>n+m = " + r3);
            Console.Write("x = ");
            double x = Get_double();
            r4 = Math.Pow(x, 5) * Math.Sqrt(Math.Abs(x - 1)) + Math.Abs(25 - Math.Pow(x, 5));
            Console.WriteLine("4) " + r4);
        }
        static void task_2()
        {
            Console.WriteLine("\nЗадача 2\n");
            Console.Write("x = ");
            double x1 = Get_double();
            Console.Write("y = ");
            double y1 = Get_double();
            bool res = (x1 <= 0 && y1 <= 0 && (7 * y1 + x1) >= -7);
            Console.WriteLine("Ответ: " + res);
        }
        static void task_3()
        {
            Console.WriteLine("\nЗадача 3\n");
            double a = 1000, b = 0.0001, f1, f2, f3, f;
            f1 = Math.Pow((a + b), 3);
            f2 = Math.Pow(a, 3) + 3 * Math.Pow(a, 2) * b;
            f3 = 3 * a * Math.Pow(b, 2) + Math.Pow(b, 3);
            f = (f1 - f2) / f3;
            Console.WriteLine("1) Тип double\nОтвет: " + f);
            float a1 = 1000, b1 = 0.0001F, t1, t2, t3, t;
            t1 = (float)Math.Pow((a1 + b1), 3);
            t2 = (float)Math.Pow(a1, 3) + 3 * (float)Math.Pow(a1, 2) * b1;
            t3 = 3 * a1 * (float)Math.Pow(b1, 2) + (float)Math.Pow(b1, 3);
            t = (t1 - t2) / t3;
            Console.WriteLine("2) Тип float\nОтвет: " + t);
        }
    }
}