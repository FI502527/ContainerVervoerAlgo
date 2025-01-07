using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Container_Vervoer.Classes
{
    public class Rij
    {
        private List<ContainerStapel> containerStapels = new List<ContainerStapel>();
        public IReadOnlyList<ContainerStapel> ContainerStapels{ get { return containerStapels; } }
        public Rij(int lengte)
        {
            MaakStapel(lengte);
        }
        public void MaakStapel(int lengte)
        {
            for(int i = 0; i< lengte; i++)
            {
                containerStapels.Add(new ContainerStapel());
            }
        }
        public bool ToevoegenContainer(Container container)
        {
            switch (container.GetType())
            {
                case ContainerType.Waardevol:
                    return ToevoegenWaardevol(container);
                case ContainerType.Gekoeld:
                    return ToevoegenGekoeld(container);
                case ContainerType.Normaal:
                    return ToevoegenNormaal(container);
            }
            return false;
        }
        public bool ToevoegenGekoeld(Container container)
        {
            return containerStapels.First().Toevoegen(container);
        }
        public bool ToevoegenNormaal(Container container)
        {
            foreach (ContainerStapel stapel in containerStapels.Skip(1))
            {
                if (stapel.Toevoegen(container) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ToevoegenWaardevol(Container container)
        {
            for (int nummer = 0; nummer < containerStapels.Count; nummer++)
            {
                if (nummer % 2 == 0)
                {
                    if (containerStapels[nummer].Toevoegen(container))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int Gewicht()
        {
            int gewicht = 0;
            foreach (ContainerStapel stapel in containerStapels)
            {
                gewicht += stapel.Gewicht();
            }
            return gewicht;
        }
    }
}
