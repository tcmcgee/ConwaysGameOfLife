using System;

namespace GameOfLife
{
    public class ConsoleDisplay
    {
        private string[,] grid = new string[10, 10];
        private int ShiftY = 0;
        private int ShiftX = 0;

        public void DisplayWorld()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            for (int rows = 0; rows < grid.GetLength(0); rows++)
            {
                for (int cols = 0; cols < grid.GetLength(1); cols++)
                {
                    Console.Write(grid[rows, cols] + " | ");
                }
                Console.WriteLine("");
                Console.WriteLine(new string('-', grid.GetLength(1) * 4));
            }
        }

        public void GetStringGrid(World world)
        {
            int numRows = grid.GetLength(0) + ShiftY;
            int numCols = grid.GetLength(1) + ShiftX;
            for (int rows = ShiftY; rows < numRows; rows++)
            {
                for (int cols = ShiftX; cols < numCols; cols++)
                {
                    grid[rows - ShiftY, cols - ShiftX] = world.GetCellAtLocation(rows, cols).ToString();
                }
            }
        }

        public void DisplayGameOverMessage()
        {
            Console.WriteLine("The World is out of living cells, life cannot continue. R.I.P.");
        }

        public string[,] GetGrid()
        {
            return grid;
        }

        public int GetShiftX()
        {
            return ShiftY;
        }

        public int GetShiftY()
        {
            return ShiftX;
        }

        public void ShiftGridViewLeft()
        {
            ShiftX--;
        }

        public void ShiftGridViewRight()
        {
            ShiftX++;
        }

        public void ShiftGridViewUp()
        {
            ShiftY--;
        }

        public void ShiftGridViewDown()
        {
            ShiftY++;
        }
    }
}