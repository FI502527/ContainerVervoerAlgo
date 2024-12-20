using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Container_Vervoer.Classes
{
    public class Schip
    {
        private List<Rij> rijen = new List<Rij>();
        public IReadOnlyList<Rij> Rijen { get { return rijen; } }
        private int MaxGewicht { get; }
        private int Breedte { get; }
        private int Lengte { get; }
        public Schip(int maxGewicht, int breedte, int lengte)
        {
            MaxGewicht = maxGewicht;
            Breedte = breedte;
            Lengte = lengte;
            MaakRijen();
        }
        public int GetBreedte()
        {
            return Breedte;
        }
        public int GetLengte()
        {
            return Lengte;
        }
        public int GetMaxGewicht()
        {
            return MaxGewicht;
        }
        private void MaakRijen()
        {
            for(int i = 0; i < Breedte; i++)
            {
                rijen.Add(new Rij(Lengte));
            }
        }
        public int Gewicht()
        {
            int gewicht = 0;
            foreach(Rij rij in rijen)
            {
                gewicht += rij.Gewicht();
            }
            return gewicht;
        }
        public bool ToevoegenContainers(List<Container> containers)
        {
            int gewichtContainers = containers.Sum(container => container.GetGewicht());
            if (gewichtContainers + Gewicht() < MaxGewicht / 2 || gewichtContainers + Gewicht() > MaxGewicht)
            {
                throw new Exception("Gewicht te zwaar of te licht.");
            }
            foreach (Container container in containers)
            {
                PlaatsContainer(container);
            }
            return true;
        }
        private bool PlaatsContainer(Container container)
        {
            if (rijen.Count % 2 != 0)
            {
                if (rijen[rijen.Count / 2].ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return PlaatsRichting(container);
        }
        private bool PlaatsRichting(Container container)
        {
            int linkseGewicht = LinkseRij().Sum(row => row.Gewicht());
            int rechtseGewicht = RechtseRij().Sum(row => row.Gewicht());

            return (linkseGewicht <= rechtseGewicht
                ? PlaatsLinks(container)
                : PlaatsRechts(container));
        }
        private List<Rij> LinkseRij()
        {
            List<Rij> linkseRij = rijen.GetRange(0, Rijen.Count / 2);
            linkseRij.Reverse();
            return linkseRij;
        }
        private List<Rij> RechtseRij()
        {
            return rijen.GetRange(rijen.Count % 2 == 0 ? rijen.Count / 2 : rijen.Count / 2 + 1, rijen.Count / 2);
        }
        private bool PlaatsLinks(Container container)
        {
            foreach (Rij rij in LinkseRij())
            {
                if (rij.ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return false;
        }
        private bool PlaatsRechts(Container container)
        {
            foreach (Rij rij in RechtseRij())
            {
                if (rij.ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return false;
        }
        private int LinkseGewicht()
        {
            int linkseGewicht = 0;
            foreach (Rij rij in LinkseRij())
            {
                int gewicht = rij.Gewicht();
                linkseGewicht =+ gewicht;
            }
            return linkseGewicht;
        }
        private int RechtseGewicht()
        {
            int rechtseGewicht = 0;
            foreach (Rij rij in RechtseRij())
            {
                int gewicht = rij.Gewicht();
                rechtseGewicht =+ gewicht;
            }
            return rechtseGewicht;
        }
        public bool Balans()
        {
            if (Math.Abs(RechtseGewicht() - LinkseGewicht()) <= 0.2 * Gewicht())
            {
                return true;
            }
            return false;
        }
    }
}
