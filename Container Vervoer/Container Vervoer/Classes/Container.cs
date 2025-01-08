using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_Vervoer.Classes
{
    public class Container
    {
        public string Name { get; private set; }
        private int Weight { get; } //IN TON NIET KG
        private ContainerType Type { get; }

        public Container(string name, int weight, ContainerType type)
        {
            Name = name;
            Type = type;

            if (weight > 4 && weight < 30)
            {
                Weight = weight;
            }
            else
            {
                throw new Exception("Container is te licht of te zwaar!");
            }
        }
        public int GetWeight()
        {
            return Weight;
        }
        public ContainerType GetType()
        {
            return this.Type;
        }
        public override string ToString()
        {
            return $"Container {Name} is {Weight} ton and {Type}";
        }
    }
}

