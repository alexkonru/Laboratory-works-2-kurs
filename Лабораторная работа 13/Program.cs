using System;
using ClassHierarchy;

namespace Лабораторная_работа_13
{
    class Program
    {
        static void Main()
        {
            // Создание двух коллекций
            MyNewCollection collection1 = new MyNewCollection();
            MyNewCollection collection2 = new MyNewCollection();

            // Создание двух объектов Journal
            Journal journal1 = Journal.Instance;
            Journal journal2 = Journal.Instance;

            // Подписка на события для первой коллекции
            collection1.CollectionCountChanged += journal1.HandleCollectionCountChanged;
            collection1.CollectionReferenceChanged += journal1.HandleCollectionReferenceChanged;

            // Подписка на события для второй коллекции
            collection2.CollectionReferenceChanged += journal2.HandleCollectionReferenceChanged;

            // Добавление элементов в коллекции
            collection1.Add(new Person());
            collection1.Add(new Person());
            collection2.Add(new Student("Александр", 19, "pstu"));
            collection2.Add(new Student());

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
