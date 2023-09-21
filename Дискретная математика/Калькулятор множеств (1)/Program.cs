using System;
using System.Collections.Generic;
using System.Linq;

namespace Калькулятор_множеств__1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            SortedSet<int> a = new SortedSet<int>();
            SortedSet<int> b = new SortedSet<int>();
            SortedSet<int> c = new SortedSet<int>();
            int begin = -500;
            int end = 500;
            do
            {
                Console.WriteLine("\n\tМЕНЮ");
                Console.Write(@"1. Задать универсум
2. Задать множество
3. Калькулятор множеств
4. Вывести множества на экран
5. Выход
 - ");
                n = Get_int();
                Console.Clear();
                switch (n)
                {
                    case 1:
                        
                        Create_universe(ref begin, ref end);
                        break;
                    case 2:
                        int method = Method();
                        string answer = "y";
                        while (answer == "y" || answer == "д")
                        {
                            Console.WriteLine("Какое множество задать? (A, B, C)");
                            string set = Console.ReadLine();
                            if (set == "A" || set == "a")
                            {
                                a = Create_set(method, begin, end, out a);
                            }
                            else
                            {
                                if (set == "B" || set == "b")
                                {
                                    b = Create_set(method, begin, end, out b);
                                }
                                else
                                {
                                    if (set == "C" || set == "c")
                                    {
                                        c = Create_set(method, begin, end, out c);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка! Нет такого множества.");
                                    }
                                }
                            }
                            Console.WriteLine("Задать ещё множество? (y/n)");
                            answer = Console.ReadLine();
                            Console.Clear();
                        }
                            break;
                    case 3:
                        Calculator(a, b, c, begin, end);
                        break;
                    case 4:
                        Console.Write("A : ");
                        PrintSet(a);
                        Console.Write("B : ");
                        PrintSet(b);
                        Console.Write("C : ");
                        PrintSet(c);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }
            }
            while (n!=5);
        }

        static int Get_int()
        {
            int x;
            string buf;
            bool correct;
            do
            {
                buf = Console.ReadLine();
                correct = int.TryParse(buf, out x);
                if (!correct)
                    Console.Write("Ошибка! Введите ещё раз.\n - ");
            }
            while (!correct);
            return x;
        }

        static void Create_universe(ref int begin, ref int end)
        {
            Console.WriteLine("Универсум по умолчанию от -500 до 500\nХотите изменить? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "д")
            {
                Console.WriteLine("Начало универсума:");
                begin = Get_int();
                Console.WriteLine("Конец универсума:");
                end = Get_int();
                if (begin < -500 || end > 500)
                {
                    Console.WriteLine("Ошибка! Нельзя задать универсум больше чем от -500 до 500");
                    begin = -500;
                    end = 500;
                }
                Console.WriteLine("Универсум задан от " + begin +  " до " + end);
            }
            else
            {
                Console.WriteLine("Универсум задан от -500 до 500");
            }
        }

        static SortedSet<int> Create_set(int m, int begin, int end, out SortedSet<int> x)
        {
            x = new SortedSet<int>();
            int n, x0;
            switch (m)
            {
                case 1:
                    int sign;
                    do
                    {
                        Console.Write(@"Элементы множества по знаку:
1. Положительные
2. Отрицательные
3. Любые
 - ");
                        sign = Get_int();
                        if (sign > 3 || sign < 1)
                        {
                            Console.WriteLine("Ошибка! Введи ещё раз.");
                        }
                    }
                    while (sign > 3 || sign < 1);
                    int parity;
                    do
                    {
                        Console.Write(@"Элементы множества по чётности:
1. Чётные
2. Нечётные
3. Любые
 - ");
                        parity = Get_int();
                        if (parity > 3 || parity < 1)
                        {
                            Console.WriteLine("Ошибка! Введи ещё раз.");
                        }
                    }
                    while (parity > 3 || parity < 1);
                    int multiple;
                    do
                    {
                        Console.Write(@"Элементы множества кратны
 n = ");
                        multiple = Get_int();
                        if (multiple == 0)
                        {
                            Console.WriteLine("Ошибка! Введи ещё раз.");
                        }
                    }
                    while (multiple != 0);
                    int b, e;
                    do
                    {
                        Console.Write(@"Элементы множества находятся в диапазоне
от ");
                        b = Get_int();
                        Console.Write("до ");
                        e = Get_int();
                        if (b >= e || b < begin || e > end)
                        {
                            Console.WriteLine("Ошибка! Введи ещё раз.");
                        }
                    }
                    while (b >= e || b < begin || e > end);
                    if (b < 0 && sign == 1)
                    {
                        b = 1;
                    }
                    if (e > 0 && sign == 2)
                    {
                        e = -1;
                    }
                    if (parity == 1)
                    {
                        for (int i = b; i <= e; i++)
                        {
                            if (i % multiple == 0 && i % 2 != 0)
                            {
                                x.Add(i);
                            }
                        }
                    }
                    else
                    {
                        if (parity == 1)
                        {
                            for (int i = b; i <= e; i++)
                            {
                                if (i % multiple == 0 && i % 2 == 0)
                                {
                                    x.Add(i);
                                }
                            }
                        }
                        else
                        {
                            for (int i = b; i <= e; i++)
                            {
                                if (i % multiple == 0)
                                {
                                    x.Add(i);
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Количество элементов множества:");
                    n = Get_int();
                    Random rnd = new Random();
                    int j = 0;
                    do
                    {
                        Console.Write(@"Элементы множества находятся в диапазоне
от ");
                        b = Get_int();
                        Console.Write("до ");
                        e = Get_int();
                        if (b >= e || b < begin || e > end)
                        {
                            Console.WriteLine("Ошибка! Введи ещё раз.");
                        }
                    }
                    while (b >= e || b < begin || e > end);
                    while (x.Count < n)
                    {
                        x0 = rnd.Next(b, e);
                        x.Add(x0);
                        j++;
                        if (j > 100)
                        {
                            n = 0;
                            Console.WriteLine("Ошибка! Невозможно создать множество такой длины в указанном диапазоне чисел.");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Количество элементов множества:");
                    n = Get_int();
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(" - ");
                        x0 = Get_int();
                        while (x0 < begin || x0 > end || x.Contains(x0))
                        {
                            if (x.Contains(x0))
                            {
                                Console.WriteLine("Ошибка! Такой элемент уже есть в множестве.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Элемент находится за пределами универсума.");
                            }
                            Console.Write(" - ");
                            x0 = Get_int();
                        }
                        x.Add(x0);
                    }
                    break;
            }
            Console.Write("Заданное множество: ");
            PrintSet(x);
            return x;
        }

        static int Method()
        {
            int n;
            do
            {
                Console.WriteLine("\tСпособ задания множеств:");
                Console.Write(@"1. По условию
2. Случайными значениями
3. Вручную
 - ");
                n = Get_int();
                Console.Clear();
                if (n > 3)
                {
                    Console.WriteLine("Ошибка!"); ;
                }
            }
            while (n > 3);
            return n;
        }

        static void PrintSet(SortedSet<int> set)
        {
            if (set.Count > 0)
            {
                foreach (int item in set)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.Write("Пустое множество");
            }
            Console.WriteLine();
        }

        static void Calculator(SortedSet<int> a, SortedSet<int> b, SortedSet<int> c, int begin, int end)
        {
            string formula_0, formula = "";
            SortedSet<int> first_set = new SortedSet<int>(), second_set = new SortedSet<int>(), set = new SortedSet<int>();
            Console.WriteLine("\tКалькулятор\n");
            Console.WriteLine(@"Операции над множествами:
+ объединение
* пересечение
\ разность
/ симметрическая разность
- дополнение");
            Console.Write("\n-> ");
            formula_0 = Console.ReadLine();
            int i = 0;
            char[] elements = { 'a', 'b', 'c', '+', '-', '*', '/', '\\'};
            foreach (char f in formula_0) // создание конечной формулы
            {
                if (f != ' ')
                {
                    if (f == 'A')
                    {
                        formula += 'a';
                    }
                    else
                    {
                        if (f == 'B')
                        {
                            formula += 'b';
                        }
                        else
                        {
                            if (f == 'C')
                            {
                                formula = "c";
                            }
                            else
                            {
                                formula += f;
                            }
                        }
                    }
                }
            }
            foreach (char f in formula) // проверка формулы
            {
                if (!elements.Contains(f))
                {
                    Console.WriteLine("Ошибка в формуле!");
                    return;
                }
            }
            formula += "0";
            i = 0;
            if (formula[i] == '-')
            {
                if (formula[i + 1] == 'a')
                {
                    Addition_set(ref a, begin, end);
                    first_set = a;
                    i++;
                }
                else
                {
                    if (formula[i + 1] == 'b')
                    {
                        Addition_set(ref b, begin, end);
                        first_set = b;
                        i++;
                    }
                    else
                    {
                        Addition_set(ref c, begin, end);
                        first_set = c;
                        i++;
                    }
                }
            }
            else
            {
                if (formula[i] == 'a')
                {
                    first_set = a;
                }
                else
                {
                    if (formula[i] == 'b')
                    {
                        first_set = b;
                    }
                    else
                    {
                        if (formula[i] == 'c') first_set = c;
                    }
                }
            }
            i++;
            while (i < formula.Length-1) // чтение формулы
            {
                if (formula[i] != '0')
                {
                    if (formula[i + 1] == '-')
                    {
                        if (formula[i + 2] == 'a')
                        {
                            Addition_set(ref a, begin, end);
                            second_set = a;
                        }
                        else
                        {
                            if (formula[i + 2] == 'b')
                            {
                                Addition_set(ref b, begin, end);
                                second_set = b;
                            }
                            else
                            {
                                Addition_set(ref c, begin, end);
                                second_set = c;
                            }
                        }
                    }
                    else
                    {
                        if (formula[i + 1] == 'a')
                        {
                            second_set = a;
                        }
                        else
                        {
                            if (formula[i + 1] == 'b')
                            {
                                second_set = b;
                            }
                            else
                            {
                                if (formula[i + 1] == 'c') second_set = c;
                            }
                        }
                    }
                    if (formula[i] == '+')
                    {
                        set = Unification_set(first_set, second_set);
                    }
                    else
                    {
                        if (formula[i] == '*')
                        {
                            set = Intersection_set(first_set, second_set);
                        }
                        else
                        {
                            if (formula[i] == '\\')
                            {
                                set = Difference_set(first_set, second_set);
                            }
                            else
                            {
                                if (formula[i] == '/')
                                {
                                    set = Symmetric_difference_set(first_set, second_set);
                                }
                            }
                        }
                    }
                }
                else
                {
                    set = first_set;
                }
                i += 2;
                first_set = set;
            }
            if (set.Count>0)
            {
                Console.Write(" = ");
                PrintSet(set);
            }
            else
            {
                Console.WriteLine(" = Пустое множество");
            }
            Console.ReadLine();
        }

        static void Addition_set(ref SortedSet<int> set, int begin, int end)
        {
            SortedSet<int> buf_set = new SortedSet<int>();
            for (int i = begin; i <= end; i++)
            {
                if (!set.Contains(i))
                {
                    buf_set.Add(i);
                }
            }
            set = buf_set;
        }

        static SortedSet<int> Unification_set(SortedSet<int> first_set, SortedSet<int> second_set)
        {
            SortedSet<int> buf_set = new SortedSet<int>();
            foreach (int item in first_set)
            {
                buf_set.Add(item);
            }
            foreach (int item in second_set)
            {
                buf_set.Add(item);
            }
            return buf_set;
        }

        static SortedSet<int> Intersection_set(SortedSet<int> first_set, SortedSet<int> second_set)
        {
            SortedSet<int> buf_set = new SortedSet<int>();
            foreach (int item in first_set)
            {
                if (second_set.Contains(item))
                {
                    buf_set.Add(item);
                }
            }
            return buf_set;
        }

        static SortedSet<int> Difference_set(SortedSet<int> f_set, SortedSet<int> s_set)
        {
            SortedSet<int> buf_set = new SortedSet<int>();
            foreach (int item in s_set)
            {
                if (!f_set.Contains(item))
                {
                    buf_set.Add(item);
                }
            }
            foreach (int item in f_set)
            {
                if (!s_set.Contains(item))
                {
                    buf_set.Add(item);
                }
            }
            return buf_set;
        }

        static SortedSet<int> Symmetric_difference_set(SortedSet<int> first_set, SortedSet<int> second_set)
        {
            SortedSet<int> set1, set2, buf_set;
            set1 = Difference_set(first_set, second_set);
            set2 = Difference_set(second_set, first_set);
            buf_set = Unification_set(set1, set2);
            return buf_set;
        }
    }
}