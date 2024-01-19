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
    public class PlantTests
    {
        [TestMethod()]
        public void PlantTest()
        {
            Plant plant = new Plant();
            Assert.IsNotNull(plant);
        }

        [TestMethod()]
        public void PlantTest1()
        {
            Plant plant = new Plant("Роза", "Дикая");
            Assert.AreEqual(plant.Name, "Роза");
            Assert.AreEqual(plant.Description, "Дикая");
        }

        [TestMethod()]
        public void PlantTest2()
        {
            Plant plant = new Plant();
            Plant plant2 = new Plant(plant);
            Assert.IsNotNull(plant2);
        }

        [TestMethod()]
        public void CloneTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = (Plant)plant.Clone();
            Assert.AreEqual((Plant)plant, plant2);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Assert.AreNotEqual(plant.Name, "name");
            Assert.AreNotEqual(plant.Description, "description");
        }

        [TestMethod()]
        public void ShallowCopyTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = (Plant)plant.ShallowCopy();
            Assert.AreEqual((Plant)plant, plant2);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = new Plant(plant);
            Assert.IsTrue(plant2.Equals(plant));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Assert.IsNotNull(plant.GetHashCode());
        }
    }
}