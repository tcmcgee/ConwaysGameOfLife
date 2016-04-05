using System.Collections.Generic;

namespace GameOfLife
{
    public class Location
    {
        private int x;
        private int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }

            set { this.x = value; }
        }

        public int Y
        {
            get { return y; }

            set { this.y = value; }
        }

        public List<Location> GetNeighbors()
        {
            List<Location> neighbors = new List<Location>();
            for (int neighborX = -1; neighborX < 2; neighborX++)
            {
                for (int neighborY = -1; neighborY < 2; neighborY++)
                {
                    if (neighborX == 0 && neighborY == 0)
                    { }
                    else
                    {
                        Location location = new Location(this.x + neighborX, this.y + neighborY);
                        neighbors.Add(location);
                    }
                }
            }
            return neighbors;
        }

        public override string ToString()
        {
            return ("(" + this.x + ", " + this.y + ")");
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType()
            && ((Location)obj).X == (this.x)
            && ((Location)obj).Y == (this.y));
        }

        public override int GetHashCode()
        {
            return this.x * 10 + this.y * 4;
        }
    }
}