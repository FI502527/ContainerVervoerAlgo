using Container_Vervoer;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public sealed class ContainerTests
    {
        [TestMethod]
        public void GetNameTest()
        {
            //Arrange
            string naam = "Container 1";

            //Act
            Container container = new Container(naam, 10, ContainerType.Normaal);

            //Assert
            Assert.AreEqual(naam, container.Name);
        }

        [TestMethod]
        public void GetWeightTest()
        {
            //Arrange
            int gewicht = 10;

            //Act
            Container container = new Container("Container 2", gewicht, ContainerType.Normaal);

            //Assert
            Assert.AreEqual(gewicht, container.GetGewicht());
        }

        [TestMethod]
        public void GetTypeTest()
        {
            //Arrange
            ContainerType type = ContainerType.Gekoeld;

            //Act
            Container container = new Container("Container 3", 10, type);

            //Assert
            Assert.AreEqual(type, container.GetType());
        }
        [TestMethod]
        public void TooHeavyContainer()
        {
            //Arrange
            int weight = 100;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Container("Container 1", weight, ContainerType.Normaal));
        }

        [TestMethod]
        public void TooLightContainer()
        {
            //Arrange
            int weight = 2;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Container("Container 1", weight, ContainerType.Normaal));
        }
    }
}
