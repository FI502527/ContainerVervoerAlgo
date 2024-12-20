using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class ContainerStapelTest
    {
        [TestMethod]
        public void ContainerToevoegenTest()
        {
            //Arrange
            ContainerStapel stapel = new ContainerStapel();
            Container container = new Container("Container 1", 10, Container_Vervoer.Type.Normaal);

            //Act
            bool status = stapel.Toevoegen(container);

            //Assert
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void ContainerAantalTest()
        {
            //Arrange
            ContainerStapel stapel = new ContainerStapel();
            Container container1 = new Container("Container 1", 10, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.Type.Gekoeld);
            Container container3 = new Container("Container 3", 20, Container_Vervoer.Type.Waardevol);

            //Act
            stapel.Toevoegen(container1);
            stapel.Toevoegen(container2);
            stapel.Toevoegen(container3);

            //Assert
            Assert.AreEqual(3, stapel.AantalContainers());
        }
        [TestMethod]
        public void ContainerStapelGewichtTest()
        {
            //Arrange
            ContainerStapel stapel = new ContainerStapel();
            Container container1 = new Container("Container 1", 10, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 15, Container_Vervoer.Type.Gekoeld);
            Container container3 = new Container("Container 3", 20, Container_Vervoer.Type.Waardevol);
            int totaalGewicht = container1.GetGewicht() + container2.GetGewicht() + container3.GetGewicht();

            //Act
            stapel.Toevoegen(container1);
            stapel.Toevoegen(container2);
            stapel.Toevoegen(container3);

            //Assert
            Assert.AreEqual(totaalGewicht, stapel.Gewicht());
        }
        [TestMethod]
        public void VolleStapelToevoegenTest()
        {
            //Arrange
            ContainerStapel stapel = new ContainerStapel();
            Container container1 = new Container("Container 1", 30, Container_Vervoer.Type.Normaal);
            Container container2 = new Container("Container 2", 30, Container_Vervoer.Type.Gekoeld);
            Container container3 = new Container("Container 3", 30, Container_Vervoer.Type.Waardevol);
            Container container4 = new Container("Container 4", 30, Container_Vervoer.Type.Normaal);
            Container container5 = new Container("Container 5", 30, Container_Vervoer.Type.Normaal);

            //Act
            stapel.Toevoegen(container1);
            stapel.Toevoegen(container2);
            stapel.Toevoegen(container3);
            stapel.Toevoegen(container4);

            //Assert
            Assert.IsFalse(stapel.Toevoegen(container5));
        }
    }
}
