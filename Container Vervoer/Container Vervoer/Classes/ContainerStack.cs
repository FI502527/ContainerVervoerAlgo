using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_Vervoer.Classes
{
    public class ContainerStack
    {
        private List<Container> stack = new List<Container>();
        public IReadOnlyList<Container> Stack { get { return stack; } }

        public bool ValueableCheck()
        {
            foreach(Container container in stack)
            {
                if(container.GetType() == ContainerType.Valueable)
                {
                    return true;
                }
            }
            return false;
        }
        public int AmountOfContainers()
        {
            return stack.Count;
        }
        public int Weight()
        {
            int weight = 0;
            foreach(Container container in stack)
            {
                weight += container.GetWeight();
            }
            return weight;
        }
        public bool HasRoom(Container container)
        {
            int weight = Weight();
            int weightContainer = container.GetWeight();
            if (weight + weightContainer <= 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TryAdding(Container container)
        {
            if(ValueableCheck() || !HasRoom(container))
            {
                return false;
            }
            stack.Add(container);
            return true;
        }
    }
}
