using Container_Vervoer;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public sealed class ContainerTests
    {
        [TestMethod]
        public void GetNaamTest()
        {
            //Arrange
            string naam = "Container 1";

            //Act
            Container container = new Container(naam, 10, ContainerType.Normaal);

            //Assert
            Assert.AreEqual(naam, container.GetNaam());
        }

        [TestMethod]
        public void GetGewichtTest()
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
            Container_Vervoer.ContainerType type = Container_Vervoer.ContainerType.Gekoeld;

            //Act
            Container container = new Container("Container 3", 10, type);

            //Assert
            Assert.AreEqual(type, container.GetType());
        }
    }
}
