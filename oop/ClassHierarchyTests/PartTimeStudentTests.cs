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
    public class PartTimeStudentTests
    {
        [TestMethod()]
        public void PartTimeStudentTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void PartTimeStudentTest1()
        {
            PartTimeStudent student = new PartTimeStudent("Александр", 19, "ПНИПУ", "ПНИПУ");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.University, "ПНИПУ");
            Assert.AreEqual(student.Employer, "ПНИПУ");
        }

        [TestMethod()]
        public void PartTimeStudentTest2()
        {
            PartTimeStudent student = new PartTimeStudent();
            PartTimeStudent student2 = new PartTimeStudent(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.University, "university");
            Assert.AreNotEqual(student.Employer, "employer");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            PartTimeStudent student2 = new PartTimeStudent(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
    }
}