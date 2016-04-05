using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class DeadCellTests
    {
        [TestMethod()]
        public void DeadCellIsNotAliveTest()
        {
            DeadCell cell = new DeadCell();

            Assert.IsFalse(cell.IsAlive());
        }

        [TestMethod()]
        public void IsAliveNextGenerationTest()
        {
            DeadCell deadCell = new DeadCell();
            List<Location> livingNeighbors = new List<Location> { new Location(0, 0), new Location(0, 0), new Location(0, 0) };

            Assert.IsFalse(deadCell.IsAlive());
            Assert.IsTrue(deadCell.IsAliveNextGeneration(livingNeighbors));
        }

        [TestMethod()]
        public void IsNotAliveNextGenerationTest()
        {
            DeadCell deadCell = new DeadCell();
            List<Location> livingNeighbors = new List<Location> { new Location(0, 0), new Location(0, 0) };

            Assert.IsFalse(deadCell.IsAliveNextGeneration(livingNeighbors));
        }
    }
}