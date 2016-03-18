using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class WorldTests
    {
        [TestMethod()]
        public void GetCellAtLocationTest()
        {
            World world = new World();
            ICell cell = world.GetCellAtLocation(new Location(0, 0));
            Assert.IsFalse(cell.IsAlive());
        }
        [TestMethod()]
        public void SetCellAliveAtLocationTest()
        {
            World world = new World();
            Location loc = new Location(0, 0);

            world.SetLivingCellAtLocation(loc);

            ICell cell = world.GetCellAtLocation(new Location(0, 0));

            Assert.IsTrue(cell.IsAlive());
        }
         [TestMethod()]
         public void GetsEmptyLivingNeighborsList()
        {
            World world = new World();

            List<Location> livingNeighborsLocations = world.GetLivingNeighborsLocations(new Location(1, 1));
   
            Assert.AreEqual(0, livingNeighborsLocations.Count);
        }

        [TestMethod()]
        public void GetsSingleLivingNeighborsList()
        {
            World world = new World();
            Location loc = new Location(1, 1);
            
            world.SetLivingCellAtLocation(new Location(1, 2));
            List<Location> livingNeighborsLocations = world.GetLivingNeighborsLocations(loc);
            

            Assert.AreEqual(1, livingNeighborsLocations.Count);
        }

        [TestMethod()]
        public void GetsFullLivingNeighborsList()
        {
            World world = new World();
            Location loc = new Location(0, 0);

            world = SetLivingCellsAtLocations(world, loc.GetNeighbors());
            
            List<Location> livingNeighborsLocations = world.GetLivingNeighborsLocations(loc);


            Assert.AreEqual(8, livingNeighborsLocations.Count);
        }

        [TestMethod()]
        public void KeepsLivingCellsThatLive()
        {
            World world = new World();
            List<Location> block = new List<Location>() { new Location(0, 1), new Location(0, 0), new Location(1, 0), new Location(1, 1) };

            world = SetLivingCellsAtLocations(world, block);
            world.NextGenerationRemainingLivingCells();


            Dictionary<Location, ICell> nextGenerationDict = world.GetNextGenerationDict();
            Assert.IsTrue(nextGenerationDict[new Location(0,0)].Equals(new LivingCell()));
            Assert.IsTrue(nextGenerationDict[new Location(1, 0)].Equals(new LivingCell()));
            Assert.IsTrue(nextGenerationDict[new Location(1, 1)].Equals(new LivingCell()));
            Assert.IsTrue(nextGenerationDict[new Location(0, 1)].Equals(new LivingCell()));
        }

        [TestMethod()]
        public void CreatesCellWhereFertile()
        {
            World world = new World();
            List<Location> birther = new List<Location>() { new Location(0, 0), new Location(1, 2), new Location(2, 0) };

            world = SetLivingCellsAtLocations(world, birther);
            world.NextGenerationNewLivingCells();

            Dictionary<Location, ICell> nextGenerationDict = world.GetNextGenerationDict();
            Assert.AreEqual(1, nextGenerationDict.Count);
            Assert.IsTrue(world.GetCellAtLocation(nextGenerationDict, new Location(1, 1)).Equals(new LivingCell()));
        }

        [TestMethod()]
        public void LivingCellsRemainsAtThreeWithAlternatingPattern()
        {
            World world = new World();
            List<Location> alternator = new List<Location>() { new Location(0, 0), new Location(0,1), new Location(0,2) };

            world = SetLivingCellsAtLocations(world, alternator);
            world.NextGenerationNewLivingCells();
            world.NextGenerationRemainingLivingCells();

            Dictionary<Location, ICell> nextGenerationDict = world.GetNextGenerationDict();

            Assert.AreEqual(3, nextGenerationDict.Count);
            Assert.IsTrue(world.GetCellAtLocation(nextGenerationDict, new Location(-1, 1)).Equals(new LivingCell()));
            Assert.IsTrue(world.GetCellAtLocation(nextGenerationDict, new Location(0, 1)).Equals(new LivingCell()));
            Assert.IsTrue(world.GetCellAtLocation(nextGenerationDict, new Location(1, 1)).Equals(new LivingCell()));
        }

        [TestMethod]
        public void TickChangesNextGenGridToCurrentGridTest()
        {
            World world = new World();
            List<Location> alternator = new List<Location>() { new Location(0, 0), new Location(0, 1), new Location(0, 2) };

            world = SetLivingCellsAtLocations(world, alternator);
            world.Tick();

            Assert.IsTrue(world.GetCellAtLocation(new Location(-1, 1)).Equals(new LivingCell()));
            Assert.IsTrue(world.GetCellAtLocation(new Location(0, 1)).Equals(new LivingCell()));
            Assert.IsTrue(world.GetCellAtLocation(new Location(1, 1)).Equals(new LivingCell()));
        }



        World SetLivingCellsAtLocations(World world, List<Location> locs)
        {
            foreach (Location loc in locs)
            {
                world.SetLivingCellAtLocation(loc);
            }
            return world;
        }
    }
}