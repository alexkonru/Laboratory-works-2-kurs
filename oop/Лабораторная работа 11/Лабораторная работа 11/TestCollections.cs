using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using ClassHierarchy;

namespace Лабораторная_работа_11
{
    public class TestCollections

    {
        private Stack<PartTimeStudent> stack1 = new Stack<PartTimeStudent>();
        private Stack<string> stack2 = new Stack<string>();
        private SortedDictionary<Person, PartTimeStudent> dict1 = new SortedDictionary<Person, PartTimeStudent>();
        private SortedDictionary<string, PartTimeStudent> dict2 = new SortedDictionary<string, PartTimeStudent>();

        public Stack<PartTimeStudent> Stack1 { get => stack1; set => stack1 = value; }
        public Stack<string> Stack2 { get => stack2; set => stack2 = value; }
        public SortedDictionary<Person, PartTimeStudent> Dict1 { get => dict1; set => dict1 = value; }
        public SortedDictionary<string, PartTimeStudent> Dict2 { get => dict2; set => dict2 = value; }

        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                PartTimeStudent st = new PartTimeStudent();
                st.RandomInit();
                Stack1.Push(st);
                Stack2.Push(st.ToString());
                Dict1[st.BasePerson] = st;
                Dict2[st.ToString()] = st;
            }
        }

        public void Push()
        {
            PartTimeStudent st = new PartTimeStudent();
            st.RandomInit();
            Stack1.Push(st);
            Stack2.Push(st.ToString());
            Dict1[st.BasePerson] = st;
            Dict2[st.ToString()] = st;
        }

        public void Pop()
        {
            Stack1.Pop();
            Stack2.Pop();
            Dict1.Remove(Dict1.Keys.Last());
            Dict2.Remove(Dict2.Keys.Last());
        }

        public void MeasureSearchTime() // поиск элементов в коллекциях
        {
            Console.WriteLine("Измерение времени поиска\n");

            Console.WriteLine("{0,-56} {1,-15} {2,-15} {3,-15} {4,-15}", "Коллекция", "Первый", "Центральный", "Последний", "Не входящий");
            Console.WriteLine(new string('-', 120));

            MeasureStack("Stack<PartTimeStudent>", Stack1, new PartTimeStudent("-", 100, "-", "-"));
            MeasureStack("Stack<string>", Stack2, new PartTimeStudent("-", 100, "-", "-").ToString());
            MeasureDictionary("SortedDictionary<Person, PartTimeStudent>", Dict1, new Person("-", 100), new PartTimeStudent("-", 100, "-", "-"));
            MeasureDictionary("SortedDictionary<string, PartTimeStudent>", Dict2, new Person("-", 100).ToString(), new PartTimeStudent("-", 100, "-", "-"));
        }

        private void MeasureStack<T>(string name, Stack<T> collection, T not) // поиск в стеке
        {
            if (collection.Count > 0)
            {
                T first = collection.Peek();
                T middle = collection.ElementAt(collection.Count / 2);
                T last = collection.ToArray()[collection.Count - 1];

                MeasureSearchTimeForElement(name, collection, first, middle, last, not);
            }
            else
            {
                Console.WriteLine($"{name} пуст. Невозмо определить время поиска.");
            }
        }

        private void MeasureDictionary<TKey, TValue>(string name, SortedDictionary<TKey, TValue>  dictionary, TKey notKey, TValue notValue) // поиск в отсортированном словаре
        {
            if (dictionary.Count > 0)
            {
                TKey firstKey = dictionary.Keys.First();
                TKey middleKey = dictionary.Keys.ElementAt(dictionary.Count / 2);
                TKey lastKey = dictionary.Keys.Last();
                

                MeasureSearchTimeForElement(name + " (по ключу)", dictionary.Keys, firstKey, middleKey, lastKey, notKey);

                TValue firstValue = dictionary.Values.First();
                TValue middleValue = dictionary.Values.ElementAt(dictionary.Count / 2);
                TValue lastValue = dictionary.Values.Last();

                MeasureSearchTimeForElement(name + " (по значению)", dictionary.Values, firstValue, middleValue, lastValue, notValue);
            }
            else
            {
                Console.WriteLine($"{name} пуст. Невозмо определить время поиска.");
            }
        }

        private void MeasureSearchTimeForElement<T>(string name, IEnumerable<T> collection, T first, T middle, T last, T notEntered) // измерение времени поиска элемента в коллекции
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan searchTime;

            stopwatch.Start();
            collection.Contains(first);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed;
            string firstTime = $"{searchTime.Ticks} ticks";

            stopwatch.Restart();
            collection.Contains(middle);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed;
            string middleTime = $"{searchTime.Ticks} ticks";

            stopwatch.Restart();
            collection.Contains(last);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed;
            string lastTime = $"{searchTime.Ticks} ticks";

            stopwatch.Restart();
            collection.Contains(notEntered);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed;
            string notTime = $"{searchTime.Ticks} ticks";

            Console.WriteLine("{0,-56} {1,-15} {2,-15} {3,-15} {4,-15}", name, firstTime, middleTime, lastTime, notTime);
        }
    }
}

