using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class ConsoleDisplayTests
    {
        private string deadCellString = " ";
        private string livingCellString = "█";

        [TestMethod()]
        public void StringGridHasEmptyCellsByDefault()
        {
            World world = new World();
            ConsoleDisplay consoleDisplay = new ConsoleDisplay();

            consoleDisplay.GetStringGrid(world);
            string[,] grid = consoleDisplay.GetGrid();

            Assert.AreEqual(deadCellString, grid[0, 0]);
        }

        [TestMethod()]
        public void StringGridHasSameLivingCellAsWorld()
        {
            World world = new World();
            ConsoleDisplay consoleDisplay = new ConsoleDisplay();

            world.SetLivingCellAtLocation(new Location(0, 0));
            consoleDisplay.GetStringGrid(world);
            string[,] grid = consoleDisplay.GetGrid();

            Assert.AreEqual(livingCellString, grid[0, 0]);
        }

        [TestMethod()]
        public void IncrementDoesntChangeGridIndexes()
        {
            World world = new World();
            ConsoleDisplay consoleDisplay = new ConsoleDisplay();

            world.SetLivingCellAtLocation(new Location(0, 0));
            consoleDisplay.GetStringGrid(world);
            consoleDisplay.ShiftGridViewDown();
            string[,] grid = consoleDisplay.GetGrid();

            Assert.AreEqual(livingCellString, grid[0, 0]);
        }
    }
}