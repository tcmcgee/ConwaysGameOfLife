using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class LivingCell : ICell
    {
        public bool IsAliveNextGeneration(List<Location> livingNeighbors)
        {
            return (livingNeighbors.Count == 2
                 || livingNeighbors.Count == 3);
        }

        public bool IsAlive()
        {
            return true;
        }

        public override bool Equals(Object obj)
        {
            return (obj.GetType() == ((LivingCell)this).GetType());
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            return "█";
        }
    }
}
