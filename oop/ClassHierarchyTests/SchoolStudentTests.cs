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
    public class SchoolStudentTests
    {
        [TestMethod()]
        public void SchoolStudentTest()
        {
            SchoolStudent student = new SchoolStudent();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void SchoolStudentTest1()
        {
            SchoolStudent student = new SchoolStudent("Александр", 19, "Лицей №1");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.School, "Лицей №1");
        }

        [TestMethod()]
        public void SchoolStudentTest2()
        {
            SchoolStudent student = new SchoolStudent();
            SchoolStudent student2 = new SchoolStudent(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.School, "school");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            SchoolStudent student2 = new SchoolStudent(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
    }
}