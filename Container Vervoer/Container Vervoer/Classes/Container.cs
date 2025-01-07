using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_Vervoer.Classes
{
    public class Container
    {
        private string Naam { get; }
        private int Gewicht { get; } //IN TON NIET KG
        private ContainerType Type { get; }

        public Container(string naam, int gewicht, ContainerType type)
        {

            Naam = naam;
            Gewicht = gewicht;
            Type = type;
        }

        public string GetNaam()
        {
            return Naam;
        }
        public int GetGewicht()
        {
            return Gewicht;
        }
        public ContainerType GetType()
        {
            return this.Type;
        }
        public override string ToString()
        {
            return $"Container {Naam} is {Gewicht} ton en {Type}";
        }
    }
}

