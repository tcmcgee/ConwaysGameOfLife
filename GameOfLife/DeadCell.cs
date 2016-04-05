using System.Collections.Generic;

namespace GameOfLife
{
    public class DeadCell : ICell
    {
        public bool IsAliveNextGeneration(List<Location> livingNeighbors)
        {
            return (livingNeighbors.Count == 3);
        }

        public bool IsAlive()
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == ((DeadCell)this).GetType());
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return " ";
        }
    }
}