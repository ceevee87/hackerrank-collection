using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions2
{
    public static class RoadsAndLibraries
    {

        #region classvars
        // store which cities are connected to which cities in an
        // adjacency list. 
        private static Dictionary<int, List<City>> adjList = null;

        // by the end of the algorithm we should know how many 
        // disjoint sets we have and the size of them.
        // the actual members are not important, only how many 
        // clusters we have and the size of each cluster.
        private static Dictionary<int, int> CityClusterSizes = null;

        private static int cityClusterId = 1;

        public static int CityClusterId { get => cityClusterId; set => cityClusterId = value; }

        internal class City
        {
            public City(int citynum)
            {
                _cityNumber = citynum;
                _cityClusterId = 0;
            }

            private int _cityNumber;
            private int _cityClusterId;

            public int CityNumber { get => _cityNumber; set => _cityNumber = value; }
            public int CityClusterId { get => _cityClusterId; set => _cityClusterId = value; }
        }

        #endregion

        // Complete the roadsAndLibraries function below.
        public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            InitAdjList(n);
            InitCityClusterCounts();
            CityClusterId = 1;

            // load up the adjList
            for (int ii = 0; ii < cities.Length; ii++)
            {
                // no guards to check length of array. fyi.
                int cityId1 = cities[ii][0];
                int cityId2 = cities[ii][1];

                AddCityRoadToAdjList(cityId1 - 1, cityId2 - 1);
                AddCityRoadToAdjList(cityId2 - 1, cityId1 - 1);
            }

            MarkCityClusters();
            int result = 0;
            foreach (int clusterId in CityClusterSizes.Keys)
            {
                result += calcCostForRoadsAndLibraries(CityClusterSizes[clusterId], c_road, c_lib);
            }

            return result;
        }

        private static int calcCostForRoadsAndLibraries(int numCities, int roadCost, int libraryCost)
        {
            // if Clib > Croad + (Clib - Croad)/numCities ==> do all roads + 1 library
            // otherwise do all libraries and no road

            float v1 = (float)libraryCost;
            float v2 = (float)roadCost;
            float v3 = (float)(libraryCost - roadCost) / (float)numCities;

            if (v1 > v2 + v3)
            {
                return (libraryCost + roadCost * (numCities - 1));
            }
            return libraryCost * numCities;
        }


        private static void InitCityClusterCounts()
        {
            if (CityClusterSizes != null)
            {
                CityClusterSizes.Clear();
                return;
            }

            CityClusterSizes = new Dictionary<int, int>();
        }

        private static void AddCityRoadToAdjList(int cityId1, int cityId2)
        {
            // should never happen because we initialzie the adjList
            // to always have an entry for each city id.
            if (!adjList.ContainsKey(cityId1))
            {
                adjList.Add(cityId1, new List<City> { new City(cityId1) });
            }

            // really should check to see if city2 is already in the list
            adjList[cityId1].Add(adjList[cityId2].ElementAt(0));

        }

        private static void InitAdjList(int n)
        {
            if (adjList != null) adjList.Clear();
            adjList = new Dictionary<int, List<City>>();
            for (int ii = 0; ii < n; ii++)
            {
                adjList.Add(ii, new List<City> { new City(ii) });
            }
        }

        private static int BFS(City c, int id)
        {
            // Basically, a BFS algorithm.

            int count = 0;
            if (c.CityClusterId > 0) return count;
            if (id <= 0) return count;

            List<City> queue = new List<City>();
            c.CityClusterId = id;
            queue.Add(c);
            count++;

            while (queue.Count > 0)
            {
                var city = queue[0];
                queue.RemoveAt(0);
                if (!adjList.ContainsKey(city.CityNumber)) continue;
                foreach (City neighborCity in adjList[city.CityNumber])
                {
                    if (neighborCity.CityClusterId > 0 || neighborCity.CityNumber == city.CityNumber) continue;
                    neighborCity.CityClusterId = id;  // mark the city as already scheduled for search
                    queue.Add(neighborCity);
                    count++;
                }
            }
            return count;
        }

        private static void MarkCityClusters()
        {
            int cityClusterId = 1;
            for (int ii = 0; ii < adjList.Count; ii++)
            {
                if (adjList[ii].Count == 1) continue;
                if (adjList[ii].ElementAt(0).CityClusterId == 0)
                {
                    int count = BFS(adjList[ii].ElementAt(0), cityClusterId);
                    if (!CityClusterSizes.ContainsKey(cityClusterId)) CityClusterSizes.Add(cityClusterId, count);
                    cityClusterId++;
                }
            }
        }

        private static void BuildCityClusterCounts()
        {
            for (int ii = 0; ii < adjList.Count; ii++)
            {
                if (adjList[ii].Count == 1) continue;
                int clusterId = adjList[ii].ElementAt(0).CityClusterId;
                if (CityClusterSizes.ContainsKey(clusterId))
                {
                    continue;
                    //CityClusterSizes[clusterId] += adjList[ii].Count;
                }
                else
                {
                    CityClusterSizes.Add(clusterId, adjList[ii].Count);
                }
            }
        }
    }
}
