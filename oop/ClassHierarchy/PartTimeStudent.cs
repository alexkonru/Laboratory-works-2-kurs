using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    public class PartTimeStudent : Student
    {
        protected string employer = "employer";

        public string Employer
        {
            get { return employer; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Ошибка: введённое значение не может являться названием компании!");
                }
                employer = value;
            }
        }

        public Person BasePerson
        {
            get
            {
                return new Person(Name, Age);
            }
        }


        public PartTimeStudent() { }

        public PartTimeStudent(string name, int age, string university, string employer) : base(name, age, university)
        {
            this.employer = employer;
        }

        public PartTimeStudent(PartTimeStudent other) : this(other.Name, other.Age, other.University, other.Employer) { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Место работы: {employer}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите название места работы: ");
            Employer = GetString();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] employers = { "АО ОДК – Стар", "АО ЭР – Телеком Холдинг", "АО Новомет–Пермь", "Яндекс", "Ростелеком", "Google" };
            Employer = employers[rnd.Next(employers.Length)];
        }

        public override bool Equals(object obj)
        {
            return obj is PartTimeStudent student &&
                   base.Equals(obj) &&
                   Name == student.Name &&
                   Age == student.Age &&
                   University == student.University &&
                   Employer == student.Employer;
        }

        public override int GetHashCode()
        {
            int hashCode = 157258573;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(University);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Employer);
            return hashCode;
        }
    }
}
