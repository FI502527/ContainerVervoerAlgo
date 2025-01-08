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
    public class ContainerStapelTest
    {
        [TestMethod]
        public void ContainerToevoegenTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container = new Container("Container 1", 10, ContainerType.Normaal);

            //Act
            bool status = stapel.Toevoegen(container);

            //Assert
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void ContainerAantalTest()
        {
            //Arrange
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 10, ContainerType.Normaal);
            Container container2 = new Container("Container 2", 15, ContainerType.Gekoeld);
            Container container3 = new Container("Container 3", 20, ContainerType.Waardevol);

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
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 10, ContainerType.Normaal);
            Container container2 = new Container("Container 2", 15, ContainerType.Gekoeld);
            Container container3 = new Container("Container 3", 20, ContainerType.Waardevol);
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
            ContainerStack stapel = new ContainerStack();
            Container container1 = new Container("Container 1", 30, ContainerType.Normaal);
            Container container2 = new Container("Container 2", 30, ContainerType.Normaal);
            Container container3 = new Container("Container 3", 30, ContainerType.Normaal);
            Container container4 = new Container("Container 4", 30, ContainerType.Normaal);
            Container container5 = new Container("Container 5", 30, ContainerType.Normaal);

            //Act
            bool result1 = stapel.Toevoegen(container1);
            bool result2 = stapel.Toevoegen(container2);
            bool result3 = stapel.Toevoegen(container3);
            bool result4 = stapel.Toevoegen(container4);
            bool result5 = stapel.Toevoegen(container5);

            //Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
            Assert.IsFalse(result5);
        }
    }
}
