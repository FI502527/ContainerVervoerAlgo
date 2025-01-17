using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class RowTest
    {
        [TestMethod]
        public void AantalRijenTest()
        {
            //Act
            int aantalStapels = 3;
            Row rij = new Row(aantalStapels);

            //Arrange
            IReadOnlyList<ContainerStack> rijList = rij.ContainerStacks;

            //Assert
            Assert.AreEqual(aantalStapels, rijList.Count);
        }
        [TestMethod]
        public void GewichtRijTest()
        {
            //Act
            Row rij = new Row(2);
            Container container1 = new Container("Container 1", 10, Container_Vervoer.ContainerType.Normal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.ContainerType.Normal);
            int totaalGewicht = container1.Weight + container2.Weight; 

            //Arrange
            rij.TryAddingContainer(container1);
            rij.TryAddingContainer(container2);

            //Assert
            Assert.AreEqual(totaalGewicht, rij.Weight());
        }
        [TestMethod]
        public void ToevoegenContainerTest()
        {
            //Act
            Row rij = new Row(3);
            Container container1 = new Container("Container 1", 10, Container_Vervoer.ContainerType.Normal);

            //Arrange
            rij.TryAddingContainer(container1);
            IReadOnlyList<ContainerStack> rijList = rij.ContainerStacks;

            //Assert
            Assert.AreEqual(container1, rijList[1].Stack[0]);
        }
    }
}
