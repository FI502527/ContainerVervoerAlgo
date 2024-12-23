﻿using System;
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
            Schip schip = new Schip(maxGewicht, breedte, lengte);

            //Assert
            Assert.AreEqual(lengte, schip.GetLengte());
            Assert.AreEqual(breedte, schip.GetBreedte());
            Assert.AreEqual(maxGewicht, schip.GetMaxGewicht());
        }
        [TestMethod]
        public void ToevoegenContainersTest()
        {
            //Arrange
            Schip schip = new Schip(30, 3, 3);
            Container container1 = new Container("Container 1", 15, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.Type.Normaal);
            List<Container> containers = new List<Container>{
                container1,
                container2
            };

            //Act
            schip.ToevoegenContainers(containers);

            //Assert
            Assert.AreEqual(container1, schip.Rijen[1].ContainerStapels[1].Stapel[0]);
            Assert.AreEqual(container2, schip.Rijen[1].ContainerStapels[1].Stapel[1]);
        }
        [TestMethod]
        public void SchipGewichtTest()
        {
            //Arrange
            int lengte = 3;
            int breedte = 3;
            int maxGewicht = 30;
            Schip schip = new Schip(maxGewicht, breedte, lengte);
            Container container1 = new Container("Container 1", 15, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.Type.Normaal);
            List<Container> containers = new List<Container>{
                container1, 
                container2
            };
            int totaalGewicht = container1.GetGewicht() + container2.GetGewicht();

            //Act
            schip.ToevoegenContainers(containers);

            //Assert
            Assert.AreEqual(totaalGewicht, schip.Gewicht());
        }
    }
}
