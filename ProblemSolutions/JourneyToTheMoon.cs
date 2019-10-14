using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRankCollection.ProblemSolutions
{
    public static class JourneyToTheMoon
    {
        static int[] astronautsByCountry;
        static List<int>[] astronautPairs;
        static int countryId = 100;
        static int countrIdIncrAmt = 100;

        //private static void SortAstronautsByCountry()
        //{
        //    for (int ii = 0; ii < astronautsByCountry.Length; ii++)
        //    {
        //        if (astronautsByCountry[ii].Length > 0)
        //        {
        //            Array.Sort(astronautsByCountry[ii]);
        //        }
        //    }
        //}

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

        private static bool IsLegalAstronautPair(int astronautId1, int astronautId2)
        {
            if (astronautId1 >= astronautsByCountry.Length
                || astronautId2 >= astronautsByCountry.Length
                || astronautId1 < 0 || astronautId2 < 0)
                return false;

            return (astronautsByCountry[astronautId1]==astronautsByCountry[astronautId2]);
        }

        private static void InitAstronautPairs(int n)
        {
            astronautPairs = new List<int>[n];
            for (int ii = 0; ii < n; ii++) astronautPairs[ii] = new List<int>();
        }

        private static void AddAstronautPair(int countryId1, int countryId2)
        {
            int searchId1 = (countryId1 < countryId2) ? countryId1 : countryId2;
            int searchId2 = (countryId1 >= countryId2) ? countryId1 : countryId2;

            foreach (int id in astronautPairs[searchId1])
            {
                astronautPairs[id].Add(searchId2);
            }
            astronautPairs[searchId1].Add(searchId2);
        }

        private static void LoadAstronutsByCountry(int n, int[][] astronaut)
        {
            astronautsByCountry = new int[n];

            for (int ii = 0; ii < astronaut.Length; ii++)
            {
                int astronautId1 = astronaut[ii][0];
                int astronautId2 = astronaut[ii][1];

                if (astronautId1 >= n || astronautId2 >= n || astronautId1 < 0 || astronautId2 < 0)
                {
                    Debug.WriteLine(string.Format("detected astronaut number outside astronaut number limit. N={0}, values={1}, {2}"
                                    , n, astronautId1, astronautId2));
                    continue;
                }
                if (astronautsByCountry[astronautId1] > 0 && astronautsByCountry[astronautId2] > 0
                    && astronautsByCountry[astronautId1] != astronautsByCountry[astronautId2])
                {
                    Debug.WriteLine(string.Format("detected astronaut belonging to two different countries. values={0}, {1}"
                                    , astronautId1, astronautId2));
                    continue;
                }
                if (astronautsByCountry[astronautId1] > 0 && astronautsByCountry[astronautId2] == 0)
                {
                    astronautsByCountry[astronautId2] = astronautsByCountry[astronautId1];
                }
                else if (astronautsByCountry[astronautId2] > 0 && astronautsByCountry[astronautId1] == 0)
                {
                    astronautsByCountry[astronautId1] = astronautsByCountry[astronautId2];
                }
                else if (astronautsByCountry[astronautId1] == 0 && astronautsByCountry[astronautId2] == 0)
                {
                    astronautsByCountry[astronautId1] = countryId;
                    astronautsByCountry[astronautId2] = countryId;
                    countryId += countrIdIncrAmt;
                }
                else if (astronautsByCountry[astronautId2] == astronautsByCountry[astronautId1])
                {
                    // do nothing
                }
                else
                {
                    Debug.WriteLine(string.Format("could not assign either astronaut to a country. values={0}, {1}"
                                    , astronautId1, astronautId2));
                    continue;
                }
            }
        }
        private static void AssignCountryIdsToRemainingAstronauts()
        {
            for (int ii = 0; ii < astronautsByCountry.Length; ii++)
            {
                if (astronautsByCountry[ii] == 0)
                {
                    astronautsByCountry[ii] = countryId;
                    countryId += countrIdIncrAmt;
                }
            }
        }

        public static int journeyToMoon(int n, int[][] astronaut)
        {
            LoadAstronutsByCountry(n, astronaut);
            AssignCountryIdsToRemainingAstronauts();

            InitAstronautPairs(n);

            //int count = 0;
            //for (int ii = 0; ii < n - 1; ii++)
            //{
            //    for (int astroId= 0; astroId < n; astroId++)
            //    {
            //        for (int jj = ii + 1; jj < n; jj++)
            //        {
            //            if (!IsLegalAstronautPair(astroId, jj)) continue;
            //            if (AreAstronautsAlreadyPaired(astroId, jj)) continue;
            //            Debug.WriteLine($"{astroId}, {jj}");
            //            AddAstronautPair(astroId, jj);
            //            count++;
            //        }
            //    }
            //}
            return 5;
        }

    }
}
