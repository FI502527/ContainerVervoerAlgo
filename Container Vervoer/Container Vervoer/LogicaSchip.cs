using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Container_Vervoer.Classes;

namespace Container_Vervoer
{
    public class LogicaSchip
    {
        public List<Container> ContainersPlaatsen = new List<Container>();
        public Ship Schip;
        public LogicaSchip(int schipLengte, int schipBreedte, int schipGewicht)
        {
            Schip = new Ship(schipGewicht, schipBreedte, schipLengte);
        }
        public bool SorteerContainers()
        {
            return Schip.ToevoegenContainers(SorteerLijst(ContainersPlaatsen));
        }
        public List<Container> SorteerLijst(List<Container> containers)
        {
            return containers.Where(container => container.GetType() == ContainerType.Gekoeld).ToList()
                .Concat(containers.Where(container => container.GetType() == ContainerType.Normaal).ToList())
                .Concat(containers.Where(container => container.GetType() == ContainerType.Waardevol).ToList())
                .ToList();
        }
    }
}
