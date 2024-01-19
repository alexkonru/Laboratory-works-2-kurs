using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    public class Plant : IInit, ICloneable
    {
        protected static Random rnd = new Random();
        private string name = "name";
        private string description = "description";

        public Plant() { }

        public Plant(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Plant(Plant other) : this(other.Name, other.Description) { }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Ошибка: введённое значение не может являться названием растения!");
                }
                name = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Ошибка: введённое значение не может являться описанием растения!");
                }
                description = value;
            }
        }

        public object Clone()
        {
            return new Plant(this);
        }

        public void Init()
        {
            Console.Write("Введите имя: ");
            Name = GetString();
            Console.Write("Введите описание: ");
            Description = GetString();
        }

        public void RandomInit()
        {
            string[] names = { "Лилия", "Роза", "Кактус", "Мак", "Берёза", "Трава" };
            Name = names[rnd.Next(names.Length)];
            string[] descriptions = { "-", "Зелёное", "Красивое", "Большое", "Цветущее" };
            Description = descriptions[rnd.Next(descriptions.Length)];
        }

        public void Show()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Описание: {Description}");
        }

        public string GetString()
        {
            string x;
            do
            {
                x = Console.ReadLine();
                if (x == null || x == "")
                    Console.Write("Ошибка: пустая строка. Введите ещё раз...\n  ");
            }
            while (x == null || x == "");
            return x;
        }

        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return obj is Plant plant &&
                   name == plant.name &&
                   Name == plant.Name &&
                   Description == plant.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = -71175355;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
