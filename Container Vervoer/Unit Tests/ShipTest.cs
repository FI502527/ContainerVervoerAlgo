using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer;
using System.Windows.Media.Media3D;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void MakeShipTest()
        {
            //Arrange
            int lengte = 3;
            int breedte = 3;
            int maxGewicht = 30;

            //Act
            Ship schip = new Ship(maxGewicht, breedte, lengte);

            //Assert
            Assert.AreEqual(lengte, schip.Length);
            Assert.AreEqual(breedte, schip.Width);
            Assert.AreEqual(maxGewicht, schip.MaxWeight);
        }
        [TestMethod]
        public void AddContainerTest()
        {
            //Arrange
            Ship schip = new Ship(30, 3, 3);
            Container container1 = new Container("Container 1", 15, Container_Vervoer.ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.ContainerType.Normal);
            List<Container> containers = new List<Container>{
                container1,
                container2
            };

            //Act
            schip.AddContainers(containers);

            //Assert
            Assert.AreEqual(container1, schip.Rows[1].ContainerStacks[1].Stack[0]);
            Assert.AreEqual(container2, schip.Rows[1].ContainerStacks[1].Stack[1]);
        }
        [TestMethod]
        public void ShipWeightTest()
        {
            //Arrange
            int lengte = 3;
            int breedte = 3;
            int maxGewicht = 30;
            Ship schip = new Ship(maxGewicht, breedte, lengte);
            Container container1 = new Container("Container 1", 15, ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, ContainerType.Normal);
            List<Container> containers = new List<Container>{
                container1,
                container2
            };
            int totaalGewicht = container1.Weight + container2.Weight;

            //Act
            schip.AddContainers(containers);

            //Assert
            Assert.AreEqual(totaalGewicht, schip.Weight());
        }

        [TestMethod]
        public void KapseizenTest()
        {
            //Arrange
            int length = 3;
            int width = 3;
            int maxWeight = 3 * 3 * 150;
            Ship ship = new Ship(maxWeight, width, length);
            Container container1 = new Container("Container 1", 15, ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, ContainerType.Normal);
            List<Container> containers = new List<Container>{
                container1,
                container2
            };

            // Act & Assert
            Assert.ThrowsException<Exception>(() => ship.AddContainers(containers));
        }

        [TestMethod]
        public void ShipBalanceTest()
        {
            // Arrange
            int length = 2;
            int width = 2;
            int maxWeight = 300;
            Ship ship = new Ship(maxWeight, width, length);

            List<Container> containers = new List<Container>
            {
                new Container("Container 1", 30, ContainerType.Normal),
                new Container("Container 2", 30, ContainerType.Normal),
                new Container("Container 3", 30, ContainerType.Normal),
                new Container("Container 4", 30, ContainerType.Normal)
            };

            // Act
            ship.AddContainers(containers);
            bool status = ship.Balance();

            // Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void ShipFailingBalanceTest()
        {
            // Arrange
            int length = 2;
            int width = 2;
            int maxWeight = 300;
            Ship ship = new Ship(maxWeight, width, length);

            List<Container> containers = new List<Container>
            {
                new Container("Container 1", 80, Container_Vervoer.ContainerType.Normal),
                new Container("Container 2", 20, Container_Vervoer.ContainerType.Normal),
                new Container("Container 3", 100, Container_Vervoer.ContainerType.Normal)
            };

            // Act
            ship.AddContainers(containers);
            bool status = ship.Balance();

            // Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void EmptyShipBalanceTest()
        {
            // Arrange
            int length = 2;
            int width = 2;
            int maxWeight = 300;
            Ship ship = new Ship(maxWeight, width, length);

            // Act
            bool status = ship.Balance();

            // Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void ShipBalanceSingleRowTest()
        {
            // Arrange
            int length = 3;
            int width = 3;
            int maxWeight = 450;
            Ship ship = new Ship(maxWeight, width, length);

            List<Container> containers = new List<Container>
            {
                new Container("Container 1", 100, ContainerType.Normal)
            };

            // Act
            ship.AddContainers(containers);
            bool isBalanced = ship.Balance();

            // Assert
            Assert.IsTrue(isBalanced, "The ship should be balanced when a single container is in the middle.");
        }

    }
}
