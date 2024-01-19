using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            TestCollections testCollections = new TestCollections(n);
            Console.WriteLine($"\nКоличество элементов в каждой коллекции: {n}\n");
            testCollections.MeasureSearchTime();
        }
    }
}
