using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class LivingCellTests
    {
        [TestMethod()]
        public void LivingCellIsAliveTest()
        {
            LivingCell cell = new LivingCell();

            Assert.IsTrue(cell.IsAlive());
        }
        [TestMethod()]
        public void IsAliveNextGenerationTest()
        {
            LivingCell livingCell = new LivingCell();
            List<Location> livingNeighbors = new List<Location> { new Location(0,0), new Location(1,1), new Location(3,3)};

            Assert.IsTrue(livingCell.IsAliveNextGeneration(livingNeighbors));    
        }

        [TestMethod()]
        public void IsNotAliveNextGenerationTest()
        {
            LivingCell livingCell = new LivingCell();
            List<Location> livingNeighbors = new List<Location> { new Location(0,0), new Location(0, 0), new Location(0, 0), new Location(0, 0) };

            Assert.IsFalse(livingCell.IsAliveNextGeneration(livingNeighbors));
        }
    }
}