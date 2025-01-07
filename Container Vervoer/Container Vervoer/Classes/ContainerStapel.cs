using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_Vervoer.Classes
{
    public class ContainerStapel
    {
        private List<Container> stapel = new List<Container>();
        public IReadOnlyList<Container> Stapel { get { return stapel; } }

        public bool WaardevolCheck()
        {
            bool status = false;
            foreach(Container container in Stapel)
            {
                if(container.GetType() == ContainerType.Waardevol)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }
        public int AantalContainers()
        {
            return Stapel.Count;
        }
        public int Gewicht()
        {
            int gewicht = 0;
            foreach(Container container in stapel)
            {
                gewicht += container.GetGewicht();
            }
            return gewicht;
        }
        public bool RuimteCheck(Container container)
        {
            int gewicht = Gewicht();
            int gewichtContainer = container.GetGewicht();
            if (gewicht + gewichtContainer <= 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Toevoegen(Container container)
        {
            if(WaardevolCheck() || !RuimteCheck(container))
            {
                return false;
            }
            stapel.Add(container);
            return true;
        }
    }
}
