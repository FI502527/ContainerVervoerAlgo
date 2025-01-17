using Container_Vervoer;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public sealed class ContainerTest
    {
        [TestMethod]
        public void GetNameTest()
        {
            //Arrange
            string naam = "Container 1";

            //Act
            Container container = new Container(naam, 10, ContainerType.Normal);

            //Assert
            Assert.AreEqual(naam, container.Name);
        }

        [TestMethod]
        public void WeightTest()
        {
            //Arrange
            int gewicht = 10;

            //Act
            Container container = new Container("Container 2", gewicht, ContainerType.Normal);

            //Assert
            Assert.AreEqual(gewicht, container.Weight);
        }

        [TestMethod]
        public void TypeTest()
        {
            //Arrange
            ContainerType type = ContainerType.Cooled;

            //Act
            Container container = new Container("Container 3", 10, type);

            //Assert
            Assert.AreEqual(type, container.Type);
        }
        [TestMethod]
        public void TooHeavyContainer()
        {
            //Arrange
            int weight = 100;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Container("Container 1", weight, ContainerType.Normal));
        }

        [TestMethod]
        public void TooLightContainer()
        {
            //Arrange
            int weight = 1;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Container("Container 1", weight, ContainerType.Normal));
        }
    }
}
