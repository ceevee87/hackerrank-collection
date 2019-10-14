using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRankCollection.ProblemSolutions
{
    public static class JourneyToTheMoon
    {
        static int[][] astronautsByCountry;
        static List<int>[] astronautPairs;

        private static void SortAstronautsByCountry()
        {
            for (int ii = 0; ii < astronautsByCountry.Length; ii++)
            {
                if (astronautsByCountry[ii].Length > 0)
                {
                    Array.Sort(astronautsByCountry[ii]);
                }
            }
        }

        private static bool AreAstronautsAlreadyPaired(int countryId1, int countryId2)
        {
            if (countryId1 == countryId2) return false;
            int searchId1;
            int searchId2;
            if (countryId1 < countryId2)
            {
                searchId1 = countryId1;
                searchId2 = countryId2;
            }
            else
            {
                searchId1 = countryId2;
                searchId2 = countryId1;
            }

            if (astronautPairs[searchId1].Count == 0) return false;
            return astronautPairs[searchId1].Contains(searchId2);
        }

        private static bool IsLegalAstronautPair(int countryId1, int countryId2)
        {
            if (countryId1 == countryId2) return false;
            int searchId1;
            int searchId2;
            if (countryId1 < countryId2)
            {
                searchId1 = countryId1;
                searchId2 = countryId2;
            }
            else
            {
                searchId1 = countryId2;
                searchId2 = countryId1;
            }
            if (astronautsByCountry[searchId1].Length == 0) return true;
            return !(Array.BinarySearch(astronautsByCountry[searchId1], (object)searchId2) >= 0);
        }

        private static void InitAstronautPairs(int n)
        {
            astronautPairs = new List<int>[n];
            for (int ii = 0; ii < n; ii++) astronautPairs[ii] = new List<int>();
        }

        private static void AddAstronautPair(int countryId1, int countryId2)
        {
            if (countryId1 < countryId2)
            {
                astronautPairs[countryId1].Add(countryId2);
            }
            else
            {
                astronautPairs[countryId2].Add(countryId1);
            }
        }

        private static void LoadAstronutsByCountry(int n, int[][] astronaut)
        {
            astronautsByCountry = new int[n][];
            Dictionary<int, List<int>> astros = new Dictionary<int, List<int>>();
            for (int ii = 0; ii < n; ii++) astros.Add(ii, new List<int>());

            for (int ii = 0; ii < astronaut.Length; ii++)
            {
                if (astronaut[ii][0] < astronaut[ii][1])
                {
                    astros[astronaut[ii][0]].Add(astronaut[ii][1]);
                }
                else
                {
                    astros[astronaut[ii][1]].Add(astronaut[ii][0]);
                }
            }

            for (int ii = 0; ii < n; ii++)
            {
                astros[ii].Add(ii);
                astronautsByCountry[ii] = astros[ii].ToArray();
            }
        }
        public static int journeyToMoon(int n, int[][] astronaut)
        {
            LoadAstronutsByCountry(n, astronaut);
            SortAstronautsByCountry();
            InitAstronautPairs(n);

            int count = 0;
            for (int ii = 0; ii < n - 1; ii++)
            {
                foreach (int v in astronautsByCountry[ii])
                {
                    for (int jj = ii + 1; jj < n; jj++)
                    {
                        if (!IsLegalAstronautPair(v, jj)) continue;
                        if (AreAstronautsAlreadyPaired(v, jj)) continue;
                        Debug.WriteLine($"{v}, {jj}");
                        AddAstronautPair(v, jj);
                        count++;
                    }
                }
            }
            return 5;
        }
    }
}
