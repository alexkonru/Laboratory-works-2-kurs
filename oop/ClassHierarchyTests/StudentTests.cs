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
    public class StudentTests
    {
        [TestMethod()]
        public void StudentTest()
        {
            Student student = new Student();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void StudentTest1()
        {
            Student student = new Student("Александр", 19, "ПНИПУ");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.University, "ПНИПУ");
        }

        [TestMethod()]
        public void StudentTest2()
        {
            Student student = new Student();
            Student student2 = new Student(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            Student student = new Student();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.University, "university");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Student student = new Student();
            student.RandomInit();
            Student student2 = new Student(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Student student = new Student();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
    }
}