using System.Collections.Generic;

namespace GameOfLife
{
    public class World
    {
        private HashSet<Location> livingCellLocationSet = new HashSet<Location>();
        private HashSet<Location> nextGenLivingCellLocationSet = new HashSet<Location>();

        public void Tick()
        {
            NextGenerationNewLivingCells();
            NextGenerationRemainingLivingCells();
            livingCellLocationSet = nextGenLivingCellLocationSet;
            nextGenLivingCellLocationSet = new HashSet<Location>();
        }

        public HashSet<Location> GetLivingCellLocationSet()
        {
            return livingCellLocationSet;
        }

        public HashSet<Location> GetNextGenerationSet()
        {
            return nextGenLivingCellLocationSet;
        }

        public ICell GetCellAtLocation(Location loc)
        {
            return GetCellAtLocation(livingCellLocationSet, loc);
        }

        public ICell GetCellAtLocation(int x, int y)
        {
            return GetCellAtLocation(livingCellLocationSet, new Location(x, y));
        }

        public void SetLivingCellsAtLocations(List<Location> locs)
        {
            foreach (Location loc in locs)
            {
                SetLivingCellAtLocation(loc);
            }
        }

        public ICell GetCellAtLocation(HashSet<Location> livingCellSet, Location location)
        {
            if (livingCellSet.Contains(location))
            {
                return new LivingCell();
            }
            else
            {
                return new DeadCell();
            }
        }

        public void SetLivingCellAtLocation(Location loc)
        {
            SetLivingCellAtLocation(livingCellLocationSet, loc);
        }

        public void SetLivingCellAtLocation(HashSet<Location> livingLocationDict, Location loc)
        {
            livingLocationDict.Add(loc);
        }

        public List<Location> GetLivingNeighborsLocations(Location location)
        {
            List<Location> neighbors = location.GetNeighbors();
            List<Location> livingNeighborCellsLocations = new List<Location>();
            foreach (Location loc in neighbors)
            {
                ICell neighborCell = GetCellAtLocation(loc);
                if (neighborCell.IsAlive())
                {
                    livingNeighborCellsLocations.Add(loc);
                }
            }
            return livingNeighborCellsLocations;
        }

        public int GetLivingCellsCount()
        {
            return livingCellLocationSet.Count;
        }

        public bool IsEmpty()
        {
            return (GetLivingCellsCount() == 0);
        }

        public void NextGenerationRemainingLivingCells()
        {
            foreach (Location livingCellLocation in livingCellLocationSet)
            {
                List<Location> livingNeighborsLocations = GetLivingNeighborsLocations(livingCellLocation);
                if (GetCellAtLocation(livingCellLocation).IsAliveNextGeneration(livingNeighborsLocations))
                {
                    nextGenLivingCellLocationSet.Add(livingCellLocation);
                }
            }
        }

        public void NextGenerationNewLivingCells()
        {
            foreach (Location location in livingCellLocationSet)
            {
                List<Location> neighbors = location.GetNeighbors();
                foreach (Location neighborLocation in neighbors)
                {
                    ICell neighborCell = GetCellAtLocation(neighborLocation);
                    if (!neighborCell.IsAlive())
                    {
                        if (neighborCell.IsAliveNextGeneration(GetLivingNeighborsLocations(neighborLocation)))
                        {
                            SetLivingCellAtLocation(nextGenLivingCellLocationSet, neighborLocation);
                        }
                    }
                }
            }
        }
    }
}