using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Container_Vervoer.Classes
{
    public class Ship
    {
        private List<Row> rows = new List<Row>();
        public IReadOnlyList<Row> Rows { get { return rows; } }
        public int MaxWeight { get; private set; }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public Ship(int maxWeight, int width, int length)
        {
            MaxWeight = maxWeight;
            Width = width;
            Length = length;
            MakeRows();
        }
        private void MakeRows()
        {
            for(int i = 0; i < Width; i++)
            {
                rows.Add(new Row(Length));
            }
        }
        public int Weight()
        {
            int weight = 0;
            foreach(Row row in rows)
            {
                weight += row.Weight();
            }
            return weight;
        }
        public bool AddContainers(List<Container> containers)
        {
            int gewichtContainers = containers.Sum(container => container.Weight);
            if (gewichtContainers + Weight() < MaxWeight / 2 || gewichtContainers + Weight() > MaxWeight)
            {
                throw new Exception("Weight too heavy or too light.");
            }
            foreach (Container container in containers)
            {
                PlaceContainer(container);
            }
            return true;
        }
        private bool PlaceContainer(Container container)
        {
            if (rows.Count % 2 != 0)
            {
                if (rows[rows.Count / 2].TryAddingContainer(container))
                {
                    return true;
                }
            }
            return PlaceDirection(container);
        }

        private bool PlaceDirection(Container container)
        {
            int leftWeight = LeftRow().Sum(row => row.Weight());
            int rightWeight = RightRow().Sum(row => row.Weight());

            return (leftWeight <= rightWeight
                ? PlaceLeft(container)
                : PlaceRight(container));
        }

        private List<Row> LeftRow()
        {
            List<Row> leftRow = rows.GetRange(0, rows.Count / 2);
            leftRow.Reverse();
            return leftRow;
        }
        private List<Row> RightRow()
        {
            return rows.GetRange(rows.Count % 2 == 0 ? rows.Count / 2 : rows.Count / 2 + 1, rows.Count / 2);
        }

        private bool PlaceLeft(Container container)
        {
            foreach (Row rij in LeftRow())
            {
                if (rij.TryAddingContainer(container))
                {
                    return true;
                }
            }

            return false;
        }
        private bool PlaceRight(Container container)
        {
            foreach (Row rij in RightRow())
            {
                if (rij.TryAddingContainer(container))
                {
                    return true;
                }
            }
            return false;
        }
        private int LeftWeight()
        {
            int leftWeight = 0;
            foreach (Row row in LeftRow())
            {
                int weight = row.Weight();
                leftWeight =+ weight;
            }
            return leftWeight;
        }
        private int RightWeight()
        {
            int rightWeight = 0;
            foreach (Row row in RightRow())
            {
                int weight = row.Weight();
                rightWeight =+ weight;
            }
            return rightWeight;
        }
        public bool Balance()
        {
            if (Math.Abs(RightWeight() - LeftWeight()) <= 0.2 * Weight())
            {
                return true;
            }
            return false;
        }
    }
}
