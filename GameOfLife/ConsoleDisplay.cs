using System;

namespace GameOfLife
{
    public class ConsoleDisplay
    {
        private string[,] grid = new string[10, 10];
        private int shiftX = 0;
        private int shiftY = 0;

        public void DisplayWorld()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            for (int rows = 0; rows < grid.GetLength(0); rows++)
            {
                Console.WriteLine(new string('-', grid.GetLength(1) * 4));
                for (int cols = 0; cols < grid.GetLength(1); cols++)
                {
                    Console.Write(grid[rows, cols] + " | ");
                }
                Console.WriteLine("");
            }
        }

        public void GetStringGrid(World world)
        {
            int numRows = grid.GetLength(0) + shiftX;
            int numCols = grid.GetLength(1) + shiftY;
            for (int rows = shiftX; rows < numRows; rows++)
            {
                for (int cols = shiftY; cols < numCols; cols++)
                {
                    grid[rows - shiftX, cols - shiftY] = world.GetCellAtLocation(rows ,cols).ToString();
                }
            }
        }

        public string[,] GetGrid()
        {
            return grid;
        }

        public int GetShiftX()
        {
            return shiftX;
        }

        public int GetShiftY()
        {
            return shiftY;
        }

        public void DecrementShiftY()
        {
            shiftY--;
        }

        public void IncrementShiftY()
        {
            shiftY++;
        }

        public void DecrementShiftX()
        {
            shiftX--;
        }

        public void IncrementShiftX()
        {
            shiftX++;
        }
    }

}
