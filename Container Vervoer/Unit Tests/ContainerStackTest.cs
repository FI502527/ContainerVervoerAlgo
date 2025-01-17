using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class ContainerStackTest
    {
        [TestMethod]
        public void AddingContainerTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container = new Container("Container 1", 10, ContainerType.Normal);

            //Act
            bool status = stapel.TryAdding(container);

            //Assert
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void AddingOntoValueableTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 10, ContainerType.Valueable);
            Container container2 = new Container("Container 2", 15, ContainerType.Normal);
            Container container3 = new Container("Container 3", 20, ContainerType.Normal);

            //Act
            bool result1 = stapel.TryAdding(container1);
            bool result2 = stapel.TryAdding(container2);
            bool result3 = stapel.TryAdding(container3);

            //Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);

        }

        [TestMethod]
        public void ContainerAmountTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 10, ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, ContainerType.Cooled);
            Container container3 = new Container("Container 3", 20, ContainerType.Valueable);

            //Act
            stapel.TryAdding(container1);
            stapel.TryAdding(container2);
            stapel.TryAdding(container3);

            //Assert
            Assert.AreEqual(3, stapel.AmountOfContainers());

        }
        [TestMethod]
        public void ContainerWeightTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 10, ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, ContainerType.Cooled);
            Container container3 = new Container("Container 3", 20, ContainerType.Valueable);
            int totaalGewicht = container1.Weight + container2.Weight + container3.Weight;

            //Act
            stapel.TryAdding(container1);
            stapel.TryAdding(container2);
            stapel.TryAdding(container3);

            //Assert
            Assert.AreEqual(totaalGewicht, stapel.Weight());
        }
        [TestMethod]
        public void AddingFullStackTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 30, ContainerType.Normal);
            Container container2 = new Container("Container 2", 30, ContainerType.Normal);
            Container container3 = new Container("Container 3", 30, ContainerType.Normal);
            Container container4 = new Container("Container 4", 30, ContainerType.Normal);
            Container container5 = new Container("Container 5", 30, ContainerType.Normal);
            Container container6 = new Container("Container 6", 30, ContainerType.Normal);

            //Act
            bool result1 = stapel.TryAdding(container1);
            bool result2 = stapel.TryAdding(container2);
            bool result3 = stapel.TryAdding(container3);
            bool result4 = stapel.TryAdding(container4);
            bool result5 = stapel.TryAdding(container5);
            bool result6 = stapel.TryAdding(container6);

            //Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
            Assert.IsFalse(result6);
        }
    }
}
