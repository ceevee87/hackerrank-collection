using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions2
{
    public static class RoadsAndLibraries
    {

        #region Class Prpperties
        // store which cities are connected to which cities in an
        // adjacency list. 
        private static Dictionary<int, List<City>> adjList = null;

        // by the end of the algorithm we should know how many 
        // disjoint sets we have and the size of them.
        // the actual members are not important, only how many 
        // clusters we have and the size of each cluster.
        private static Dictionary<int, int> CityClusterSizes = null;

        internal class City
        {
            public City(int citynum)
            {
                _cityNumber = citynum;
                _cityClusterId = 0;
            }

            private int _cityNumber;
            private int _cityClusterId;

            public int CityNumber
            {
                get { return _cityNumber; }
                set
                {
                    _cityNumber = value;
                }
            }
            public int CityClusterId
            {
                get { return _cityClusterId; }
                set { _cityClusterId = value; }
            }
        }
        #endregion

        private static long calcRoadAndLibraryCostForCityCluster(int numCities, int roadCost, int libraryCost)
        {
            // if a city is isolated we must build a library for it.
            if (numCities == 1) return libraryCost;

            // otherwise, there are only two possible solutions:
            // 1. build 1 library (and never more) and have it serve a city cluster (MST)
            // 2. build libraries for all cities
            // it's only one of the two items above for each cluster
            if (roadCost >= libraryCost)
            {
                return libraryCost * numCities;
            }
            return (libraryCost + roadCost * (numCities - 1));
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

        private static void AddCityPairToAdjList(int cityId1, int cityId2)
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

        private static void IntiCityAdjacenyList(int n)
        {
            if (adjList != null) adjList.Clear();
            adjList = new Dictionary<int, List<City>>();

            // the adjaceny list is indexed by an integer
            // but we need city information at each "node" of the list
            // so, I add in the city itself as the first element in the list
            // for each dictionary entry.
            // example: the first entry in adjList[4] is city 4. 
            for (int ii = 0; ii < n; ii++)
            {
                adjList.Add(ii, new List<City> { new City(ii) });
            }
        }

        private static int GroupCitiesIntoClusters(City c, int id)
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

        private static void CountAndRecordCityClusterSizes()
        {
            int cityClusterId = 1;
            for (int ii = 0; ii < adjList.Count; ii++)
            {
                // if this city is by itself (no road leaving/entering)...
                if (adjList[ii].Count == 1)
                {
                    if (!CityClusterSizes.ContainsKey(cityClusterId)) CityClusterSizes.Add(cityClusterId++, 1);
                    continue;
                }

                // otherwise, this city is part of a network of cities specified by 
                // the 2D array supplied as input to this problem.
                // find out how large that network is (cluster)
                if (adjList[ii].ElementAt(0).CityClusterId == 0)
                {
                    int clusterSize = GroupCitiesIntoClusters(adjList[ii].ElementAt(0), cityClusterId);
                    if (!CityClusterSizes.ContainsKey(cityClusterId)) CityClusterSizes.Add(cityClusterId, clusterSize);
                    cityClusterId++;
                }
            }
        }

        private static void PopulateCityAdjacencyList(int[][] cities)
        {
            // the problem supplies city numbers starting at 1 ...
            // I adjust these to be from 0 ...

            // load up the adjList
            for (int ii = 0; ii < cities.Length; ii++)
            {
                // no guards to check length of array. fyi.
                int cityId1 = cities[ii][0];
                int cityId2 = cities[ii][1];

                AddCityPairToAdjList(cityId1 - 1, cityId2 - 1);
                AddCityPairToAdjList(cityId2 - 1, cityId1 - 1);
            }
        }

        private static long calcTotalCostForRoadsAndLibraries(int c_road, int c_lib)
        {
            long result = 0;
            foreach (int clusterId in CityClusterSizes.Keys)
            {
                result += calcRoadAndLibraryCostForCityCluster(CityClusterSizes[clusterId], c_road, c_lib);
            }
            return result;
        }

        // Complete the roadsAndLibraries function below.
        public static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            IntiCityAdjacenyList(n);
            InitCityClusterCounts();
            PopulateCityAdjacencyList(cities);
            CountAndRecordCityClusterSizes();

            long result = calcTotalCostForRoadsAndLibraries(c_road, c_lib);
            return result;
        }
    }
}
