using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassHierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy.Tests
{
    [TestClass()]
    public class PersonAgeTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            PersonAge personAge = new PersonAge();
            Assert.AreEqual(personAge.Compare(person, person2), 0);
        }
    }
}