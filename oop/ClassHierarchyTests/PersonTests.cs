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
    public class PersonTests
    {
        [TestMethod()]
        public void PersonTest()
        {
            Person person = new Person();
            Assert.IsNotNull(person);
        }

        [TestMethod()]
        public void PersonTest1()
        {
            Person person = new Person("Александр", 19);
            Assert.AreEqual(person.Name, "Александр");
            Assert.AreEqual(person.Age, 19);
        }

        [TestMethod()]
        public void PersonTest2()
        {
            Person person = new Person();
            Person person2 = new Person(person);
            Assert.IsNotNull(person2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTest3()
        {
            Person person = new Person("", 19);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            Person person = new Person();
            person.RandomInit();
            Assert.AreNotEqual(person.Name, "name");
            Assert.AreNotEqual(person.Age, 0);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            Assert.IsTrue(person2.Equals(person));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Person person = new Person();
            person.RandomInit();
            Assert.IsNotNull(person.GetHashCode());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            Assert.AreEqual(person.CompareTo(person2), 0);
        }

        [TestMethod()]
        public void CloneTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = (Person)person.Clone();
            Assert.AreEqual((Person)person, person2);
        }
    }
}