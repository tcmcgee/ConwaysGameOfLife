using System.Collections.Generic;

namespace GameOfLife
{
    public interface ICell
    {
        bool IsAliveNextGeneration(List<Location> livingNeighbors);

        bool IsAlive();

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}