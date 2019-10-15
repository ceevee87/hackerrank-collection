using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions
{
    public static class JourneyToTheMoon
    {
        static int[] astronautsByCountry;
        static Dictionary<int, int> astronautCountsByCountry;

        static int countryId = 100;
        static int countrIdIncrAmt = 100;

        private static bool IsLegalAstronautPair(int astronautId1, int astronautId2)
        {
            if (astronautId1 >= astronautsByCountry.Length
                || astronautId2 >= astronautsByCountry.Length
                || astronautId1 < 0 || astronautId2 < 0)
                return false;

            return (astronautsByCountry[astronautId1] == astronautsByCountry[astronautId2]);
        }

        private static void BuildAstronutsByCountry(int n, int[][] astronaut)
        {
            astronautsByCountry = new int[n];

            for (int ii = 0; ii < astronaut.Length; ii++)
            {
                int astronautId1 = astronaut[ii][0];
                int astronautId2 = astronaut[ii][1];

                Debug.Write(string.Format("{0} ... {1}, {2} -->", ii, astronautId1, astronautId2));
                if (astronautId1 >= n || astronautId2 >= n || astronautId1 < 0 || astronautId2 < 0)
                {
                    continue;
                }

                if (astronautsByCountry[astronautId1] > 0 && astronautsByCountry[astronautId2] > 0
                    && astronautsByCountry[astronautId1] != astronautsByCountry[astronautId2])
                {
                    // we'll deal with merging in a separate fn.
                    Debug.WriteLine("");
                    continue;
                }
                if (astronautsByCountry[astronautId1] > 0 && astronautsByCountry[astronautId2] == 0)
                {
                    Debug.WriteLine(string.Format("assigning astronaut {0} to country {1}"
                                    , astronautId2, astronautsByCountry[astronautId1]));
                    astronautsByCountry[astronautId2] = astronautsByCountry[astronautId1];
                }
                else if (astronautsByCountry[astronautId2] > 0 && astronautsByCountry[astronautId1] == 0)
                {
                    Debug.WriteLine(string.Format("assigning astronaut {0} to country {1}"
                                    , astronautId1, astronautsByCountry[astronautId2]));
                    astronautsByCountry[astronautId1] = astronautsByCountry[astronautId2];
                }
                else if (astronautsByCountry[astronautId1] == 0 && astronautsByCountry[astronautId2] == 0)
                {
                    Debug.WriteLine(string.Format("assigning astronauts {0}, {1}, to country {2}"
                                    , astronautId1, astronautId2, countryId));
                    astronautsByCountry[astronautId1] = countryId;
                    astronautsByCountry[astronautId2] = countryId;
                    countryId += countrIdIncrAmt;
                }
                else if (astronautsByCountry[astronautId2] == astronautsByCountry[astronautId1])
                {
                    // do nothing
                    Debug.WriteLine(string.Format("Doing nothing ... iteration {0}", ii));
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
        private static void BuildAstronautCountsByCountry()
        {
            astronautCountsByCountry = new Dictionary<int, int>();
            for (int astronautId = 0; astronautId < astronautsByCountry.Length; astronautId++)
            {
                int countryId = astronautsByCountry[astronautId];
                if (astronautCountsByCountry.ContainsKey(countryId))
                {
                    astronautCountsByCountry[countryId]++;
                }
                else
                {
                    astronautCountsByCountry.Add(countryId, 1);
                }
            }
        }

        private static void MergeCountryAssignments(int n, int[][] astronaut)
        {
            for (int ii = 0; ii < astronaut.Length; ii++)
            {
                int astronautId1 = astronaut[ii][0];
                int astronautId2 = astronaut[ii][1];

                Debug.Write(string.Format("{0} ... {1}, {2} -->", ii, astronautId1, astronautId2));
                if (astronautId1 >= n || astronautId2 >= n || astronautId1 < 0 || astronautId2 < 0)
                {
                    Debug.WriteLine(string.Format("detected astronaut number outside astronaut number limit. N={0}, values={1}, {2}"
                                    , n, astronautId1, astronautId2));
                    continue;
                }
                // need to perform merge fn.
                if (astronautsByCountry[astronautId1] > 0 && astronautsByCountry[astronautId2] > 0
                    && astronautsByCountry[astronautId1] != astronautsByCountry[astronautId2])
                {
                    int mergeToCountryId = astronautsByCountry[astronautId2];
                    int mergeFromCountryId = astronautsByCountry[astronautId1];

                    Debug.Write(string.Format("Merging astronauts from country {0} into {1} "
                        , mergeFromCountryId, mergeToCountryId));

                    int numAstronautsMerged = 0;
                    for (int jj = 0; jj < n; jj++)
                    {
                        if (astronautsByCountry[jj] == mergeFromCountryId)
                        {
                            astronautsByCountry[jj] = mergeToCountryId;
                            numAstronautsMerged++;
                        }
                    }
                    Debug.WriteLine(string.Format("({0} merged)", numAstronautsMerged));
                    continue;
                }
                else
                {
                    Debug.WriteLine("");
                }
            }
        }

        public static long journeyToMoon(int n, int[][] astronaut)
        {
            BuildAstronutsByCountry(n, astronaut);
            AssignCountryIdsToRemainingAstronauts();
            MergeCountryAssignments(n, astronaut);
            BuildAstronautCountsByCountry();

            long pairCount = 0;
            int[] countryIds = astronautCountsByCountry.Keys.ToArray();
            Array.Sort(countryIds);

            for (int ii = 0; ii < countryIds.Length - 1; ii++)
            {
                int countryId1 = countryIds[ii];
                for (int jj = ii + 1; jj < countryIds.Length; jj++)
                {
                    int countryId2 = countryIds[jj];
                    pairCount += astronautCountsByCountry[countryId1] * astronautCountsByCountry[countryId2];
                }
            }
            return pairCount;
        }
    }
}
