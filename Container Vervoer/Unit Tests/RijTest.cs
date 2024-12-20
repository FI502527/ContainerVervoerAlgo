using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class RijTest
    {
        [TestMethod]
        public void AantalRijenTest()
        {
            //Act
            int aantalStapels = 3;
            Rij rij = new Rij(aantalStapels);

            //Arrange
            IReadOnlyList<ContainerStapel> rijList = rij.ContainerStapels;

            //Assert
            Assert.AreEqual(aantalStapels, rijList.Count);
        }
        [TestMethod]
        public void GewichtRijTest()
        {
            //Act
            Rij rij = new Rij(2);
            Container container1 = new Container("Container 1", 10, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.Type.Normaal);
            int totaalGewicht = container1.GetGewicht() + container2.GetGewicht(); 

            //Arrange
            rij.ToevoegenContainer(container1);
            rij.ToevoegenContainer(container2);

            //Assert
            Assert.AreEqual(totaalGewicht, rij.Gewicht());
        }
        [TestMethod]
        public void ToevoegenContainerTest()
        {
            //Act
            Rij rij = new Rij(3);
            Container container1 = new Container("Container 1", 10, Container_Vervoer.Type.Normaal);

            //Arrange
            rij.ToevoegenContainer(container1);
            IReadOnlyList<ContainerStapel> rijList = rij.ContainerStapels;

            //Assert
            Assert.AreEqual(container1, rijList[1].Stapel[0]);
        }
    }
}
