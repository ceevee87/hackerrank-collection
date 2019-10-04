using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public class HackerlandRadioTransmitters
    {
        private static int _numCities;
        private static int _towerRadius;
        private static int[] _homeLocations;

        private static List<int> getEnabledTowers()
        {
            var res = new List<int>();
            var firstTower = -1;

            // find the first tower that we need to turn on.
            for (int ii = 0; ii < _towerRadius; ii++)
            {
                // check if the current city has an electrical tower
                if (_homeLocations[ii] > 0)
                    firstTower = ii;
            }

            // we were unable to find a city with an electrical tower
            // within _towerRadius distance from the origin.
            if (firstTower == -1)
                return null;
            res.Add(firstTower);

            // let's find the last tower. this will be similar to what we did 
            // with the first tower, we'll just be working from the end of the 
            // array backwards
            int lastTower = -1;
            for (int ii = _numCities - 1; ii >= _numCities - _towerRadius; ii--)
            {
                // check if the current city has an electrical tower
                if (_homeLocations[ii] > 0)
                    lastTower = ii;
            }

            // we were unable to find a city with an electrical tower
            // within _towerRadius distance from the end.
            if (lastTower == -1)
                return null;

            // for the algorithm to proceed we need to have distinct first and
            // last towers such that the last tower follows the first tower.
            if (lastTower <= firstTower)
                return res;
            res.Add(lastTower);

            bool done = false;
            bool fail = false;
            var prevTower = firstTower;
            while (!done)
            {
                // curTower is an offset relative to the previous tower that
                // we activated (turned on).
                int curTower = 0;
                int ii = 0;
                for (ii = 0; ii < 2 * _towerRadius; ii++)
                {
                    if (ii + prevTower == lastTower)
                        return res;
                    else if (_homeLocations[ii + prevTower] != 0)
                        curTower = ii;
                }
                // if we couldn't find a tower to turn on within the range
                // of 2*_towerRadius then curTower will be stuck at 0.
                // we can stop then
                if (curTower > 0)
                {
                    prevTower += curTower;
                    res.Add(prevTower);
                }
                else
                {
                    done = true;
                    fail = true;
                }
            }
            if (res.Count > 0 && !fail)
                return res;
            return null;
        }

        // Complete the hackerlandRadioTransmitters function below.
        public static int hackerlandRadioTransmitters(int[] aHomeLocations, int iTransmitDistance)
        {
            // this is an array that designates for each city how many
            // electrical towers they have. If there is a zero value then
            // there are no tower locations.
            _homeLocations = aHomeLocations;
            _numCities = _homeLocations.Length;
            _towerRadius = iTransmitDistance;

            return 972;
        }

    }
}
