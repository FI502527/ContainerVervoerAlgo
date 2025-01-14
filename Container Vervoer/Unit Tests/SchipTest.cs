using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class SchipTest
    {
        [TestMethod]
        public void MaakSchipTest()
        {
            //Arrange
            int lengte = 3;
            int breedte = 3;
            int maxGewicht = 30;

            //Act
            Ship schip = new Ship(maxGewicht, breedte, lengte);

            //Assert
            Assert.AreEqual(lengte, schip.GetLength());
            Assert.AreEqual(breedte, schip.GetWidth());
            Assert.AreEqual(maxGewicht, schip.GetMaxWeight());
        }
        [TestMethod]
        public void ToevoegenContainersTest()
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
        public void SchipGewichtTest()
        {
            //Arrange
            int lengte = 3;
            int breedte = 3;
            int maxGewicht = 30;
            Ship schip = new Ship(maxGewicht, breedte, lengte);
            Container container1 = new Container("Container 1", 15, Container_Vervoer.ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.ContainerType.Normal);
            List<Container> containers = new List<Container>{
                container1, 
                container2
            };
            int totaalGewicht = container1.GetWeight() + container2.GetWeight();

            //Act
            schip.AddContainers(containers);

            //Assert
            Assert.AreEqual(totaalGewicht, schip.Weight());
        }
    }
}
