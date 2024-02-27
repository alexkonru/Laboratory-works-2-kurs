using System;

namespace Лабораторная_работа_13
{
    class Program
    {
        static void Main()
        {
            // Создание двух коллекций
            MyNewCollection<int> collection1 = new MyNewCollection<int>();
            MyNewCollection<string> collection2 = new MyNewCollection<string>();

            // Создание двух объектов Journal
            Journal journal1 = Journal.Instance;
            Journal journal2 = Journal.Instance;

            // Подписка на события для первой коллекции
            collection1.CollectionCountChanged += journal1.HandleCollectionCountChanged;
            collection1.CollectionReferenceChanged += journal1.HandleCollectionReferenceChanged;

            // Подписка на события для второй коллекции
            collection2.CollectionReferenceChanged += journal2.HandleCollectionReferenceChanged;

            // Добавление элементов в коллекции
            collection1.Add(1);
            collection1.Add(2);
            collection2.Add("A");
            collection2.Add("B");

            // Удаление элементов из коллекций
            collection1.Remove(0);
            collection2.Remove(1);

            // Вывод данных об объекте Journal1
            Console.WriteLine("Journal1 Entries:");
            foreach (var entry in journal1.GetEntries())
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine();

            // Вывод данных об объекте Journal2
            Console.WriteLine("Journal2 Entries:");
            foreach (var entry in journal2.GetEntries())
            {
                Console.WriteLine(entry);
            }
        }
    }
}
