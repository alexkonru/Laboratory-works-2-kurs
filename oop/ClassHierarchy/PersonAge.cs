using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ClassHierarchy
{
    public class PersonAge : IComparer<Person>
    {
        public virtual int Compare(Person p1, Person p2)
        {
            return p1.Age.CompareTo(p2.Age);
        }
    }
}
