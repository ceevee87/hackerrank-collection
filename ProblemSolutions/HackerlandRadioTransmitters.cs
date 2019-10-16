using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public class HackerlandRadioTransmitters
    {
        private static int _numHouses;
        private static int _towerRadius;
        private static int[] _homeLocations;

        public static int NumHouses
        {
            get { return _numHouses; }
            set { _numHouses = value; }
        }
        public static int TowerRadius
        {
            get { return _towerRadius; }
            set { _towerRadius = value; }
        }
        public static int[] HomeLocations
        {
            get { return _homeLocations; }
            set { _homeLocations = value; Array.Sort(_homeLocations); }
        }

        private enum SearchDirection { Left, Right };

        private static int GetFarthestHouseCoveredFromLocation(int iHouse, SearchDirection eSearchDir)
        {
            // i put this in in case I have to solve this problem
            // iterating from left to right or right to left in the _homeLocations array
            int iIncrementVal = (eSearchDir == SearchDirection.Right) ? 1 : -1;

            // iHouse is the i-th house in a sorted list of house locations
            // think of iHouse as the index into the array of _homeLocations
            // _homeLocations[iHouse] is the location of the house at index iHouse

            if (iHouse < 0 || iHouse >= NumHouses) return -1;
            int iNextHouse = iHouse + iIncrementVal;
            while ((iNextHouse < NumHouses && iNextHouse >= 0)
                    && Math.Abs(HomeLocations[iNextHouse] - HomeLocations[iHouse]) <= TowerRadius)
            {
                iNextHouse += iIncrementVal;
            }
            return iNextHouse - iIncrementVal;
        }

        // Complete the hackerlandRadioTransmitters function below.
        public static int hackerlandRadioTransmitters()
        {
            int iNumTransmittersRequired = 0;
            int ii = 0; // i-th house
            while (ii < NumHouses)
            {
                ii = GetFarthestHouseCoveredFromLocation(ii, SearchDirection.Right);
                if (ii == -1) break;
                ii = GetFarthestHouseCoveredFromLocation(ii, SearchDirection.Right);
                if (ii == -1) break;
                iNumTransmittersRequired++;
                ii++;
            }
            return iNumTransmittersRequired;
        }
    }
}
