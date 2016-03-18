using System.Collections.Generic;

namespace GameOfLife
{
    public class World
	{
		Dictionary<Location,ICell> livingCellLocationDict =  new Dictionary<Location,ICell>();
        Dictionary<Location, ICell> nextGenLivingCellLocationDict = new Dictionary<Location, ICell>();

        public void Tick()
        {
            NextGenerationNewLivingCells();
            NextGenerationRemainingLivingCells();
            livingCellLocationDict = nextGenLivingCellLocationDict;
            nextGenLivingCellLocationDict = new Dictionary<Location, ICell>();
        }
        public Dictionary<Location,ICell> GetLivingCellLocationDict()
        {
            return livingCellLocationDict;
        }
        public Dictionary<Location, ICell> GetNextGenerationDict()
        {
            return nextGenLivingCellLocationDict;
        }

        public ICell GetCellAtLocation(Location loc)
        {
            return GetCellAtLocation(livingCellLocationDict, loc);
        }

        public void SetLivingCellsAtLocations(List<Location> locs)
        {
            foreach (Location loc in locs)
            {
                SetLivingCellAtLocation(loc);
            }
        }

        public ICell GetCellAtLocation(Dictionary<Location, ICell> livingCellDict, Location location)
        {
            ICell cell;
            bool found = livingCellDict.TryGetValue(location, out cell);
            if (found)
            { }
            else
            {
                cell = new DeadCell();
            }
            return cell;
        }

        public void SetLivingCellAtLocation(Location loc)
		{
			livingCellLocationDict[loc] =  new LivingCell();
		}

        public void SetLivingCellAtLocation(Dictionary<Location, ICell> livingLocationDict, Location loc)
        {
            livingLocationDict[loc] = new LivingCell();
        }

        public List<Location> GetLivingNeighborsLocations(Location location)
		{
			List < Location > neighbors = location.GetNeighbors();
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

        public void NextGenerationRemainingLivingCells()
        {
            foreach (Location livingCellLocation in livingCellLocationDict.Keys)
            {
                List<Location> livingNeighborsLocations = GetLivingNeighborsLocations(livingCellLocation);
                if (GetCellAtLocation(livingCellLocation).IsAliveNextGeneration(livingNeighborsLocations))
                {
                    nextGenLivingCellLocationDict[livingCellLocation] = new LivingCell();
                }
            }
        }

        public void NextGenerationNewLivingCells()
        {
            foreach (Location location in livingCellLocationDict.Keys)
            {
                List<Location> neighbors = location.GetNeighbors();
                foreach(Location neighborLocation in neighbors)
                {
                    ICell neighborCell = GetCellAtLocation(neighborLocation);
                    if (neighborCell.IsAlive())
                    { }   
                    else
                    {
                        if (neighborCell.IsAliveNextGeneration(GetLivingNeighborsLocations(neighborLocation)))
                        {

                            SetLivingCellAtLocation(nextGenLivingCellLocationDict, neighborLocation);
                        }
                    }
                }
            }
        }
    }
}
