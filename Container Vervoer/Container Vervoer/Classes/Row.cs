using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Container_Vervoer.Classes
{
    public class Row
    {
        private List<ContainerStack> containerStacks = new List<ContainerStack>();
        public IReadOnlyList<ContainerStack> ContainerStacks { get { return containerStacks; } }
        public Row(int length)
        {
            MakeStack(length);
        }
        public void MakeStack(int length)
        {
            for(int i = 0; i< length; i++)
            {
                containerStacks.Add(new ContainerStack());
            }
        }
        public bool TryAddingContainer(Container container)
        {
            switch (container.Type)
            {
                case ContainerType.Valueable:
                    return TryAddingValueable(container);
                case ContainerType.Cooled:
                    return TryAddingCooled(container);
                case ContainerType.Normal:
                    return TryAddingNormal(container);
            }
            return false;
        }
        public bool TryAddingCooled(Container container)
        {
            return containerStacks.First().TryAdding(container);
        }
        public bool TryAddingNormal(Container container)
        {
            foreach (ContainerStack stack in containerStacks.Skip(1))
            {
                if (stack.TryAdding(container) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TryAddingValueable(Container container)
        {
            for (int number = 0; number < containerStacks.Count; number++)
            {
                if (number % 2 == 0)
                {
                    if (containerStacks[number].TryAdding(container))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int Weight()
        {
            int weight = 0;
            foreach (ContainerStack stack in containerStacks)
            {
                weight += stack.Weight();
            }
            return weight;
        }
    }
}
