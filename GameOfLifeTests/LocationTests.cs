using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
    [TestClass()]
    public class LocationTests
    {
        [TestMethod()]
        public void GetXTest()
        {
            Location location = new Location(0, 0);

            Assert.AreEqual(0, location.X);
        }

        [TestMethod()]
        public void GetYTest()
        {
            Location location = new Location(0, 0);

            Assert.AreEqual(0, location.Y);
        }

        [TestMethod()]
        public void GetLocationNeighborsTest()
        {
            Location location = new Location(0, 0);

            List<Location> neighbors = location.GetNeighbors();
            List<Location> expectedNeighbors = new List<Location> { new Location(1, 0), new Location(-1, 0), new Location(0, -1), new Location(0, 1), new Location(-1, -1), new Location(1, 1), new Location(-1, 1), new Location(1, -1) };

            Assert.IsTrue(LocationListsAreEqual(neighbors, expectedNeighbors));
        }

        [TestMethod()]
        public void TrueIfEqualLocationTest()
        {
            Location location = new Location(1, 1);

            Location otherLocation = new Location(1, 1);

            Assert.IsTrue(location.Equals(otherLocation));
        }

        [TestMethod()]
        public void FalseIfNotEqualLocationsTest()
        {
            Location location = new Location(1, 1);

            Location otherLocation = new Location(0, 1);

            Assert.IsFalse(location.Equals(otherLocation));
        }

        [TestMethod()]
        public void SameLocationHasSameHashCodeTest()
        {
            Location location = new Location(2, 2);

            Location otherLocation = new Location(2, 2);

            Assert.AreEqual(location.GetHashCode(), otherLocation.GetHashCode());
        }

        [TestMethod()]
        public void DifferentLocationHasDifferentHashCodeTest()
        {
            Location location = new Location(1, 2);

            Location otherLocation = new Location(2, 2);

            Assert.AreNotEqual(location.GetHashCode(), otherLocation.GetHashCode());
        }

        public bool LocationListsAreEqual(List<Location> locations1, List<Location> locations2)
        {
            if (locations1.Count != locations2.Count)
            {
                return false;
            }
            else {
                foreach (Location location1 in locations1)
                {
                    bool matched = false;
                    foreach (Location location2 in locations2)
                    {
                        if (location1.Equals(location2))
                        {
                            matched = true;
                            break;
                        }
                    }
                    if (matched == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}