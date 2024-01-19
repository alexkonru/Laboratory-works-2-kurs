using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    public class SchoolStudent : Person
    {
        protected string school = "school";

        public string School
        {
            get { return school; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Ошибка: введённое значение не может являться именем!");
                }
                school = value;
            }
        }

        public Person BasePerson
        {
            get
            {
                return new Person(Name, Age);
            }
        }


        public SchoolStudent() { }

        public SchoolStudent(string name, int age, string school) : base(name, age)
        {
            School = school;
        }

        public SchoolStudent(SchoolStudent other) : this(other.Name, other.Age, other.School) { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Школа: {school}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите название школы: ");
            School = GetString();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] schools = { "Школа №1", "Школа №3", "Лицей №1", "Лицей №2", "Политехническая школа" };
            School = schools[rnd.Next(schools.Length)];
        }

        public override bool Equals(object obj)
        {
            return obj is SchoolStudent student &&
                   base.Equals(obj) &&
                   Name == student.Name &&
                   Age == student.Age &&
                   School == student.School;
        }

        public override int GetHashCode()
        {
            int hashCode = -24908831;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(School);
            return hashCode;
        }
    }
}
