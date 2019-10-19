using HackerRankCollection.ProblemSolutions2;
using NUnit.Framework;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests2
{
    [TestFixture]
    public class RoadsAndLibrariesTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\RoadsAndLibraries");

        internal class InputDataRoadsAndLibraries
        {
            public int costRoad;
            public int costLibrary;
            public int numCities;
            public int[][] cityPairs;

            public InputDataRoadsAndLibraries(int cr, int cl, int n, int[][] cps)
            {
                costRoad = cr;
                costLibrary = cl;
                numCities = n;
                cityPairs = cps;
            }
        }

        [Test]
        public void sample0Test()
        {
            InputDataRoadsAndLibraries[] oData = GetInputData(_sTestDataRootDir + "sample0_input.txt");
            long[] result = new long[oData.Length];
            for (int ii = 0; ii < oData.Length; ii++)
            {
                result[ii] = RoadsAndLibraries.roadsAndLibraries(oData[ii].numCities, oData[ii].costLibrary, oData[ii].costRoad, oData[ii].cityPairs);
            }
            long[] expected = new long[1] { 19 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void sample1Test()
        {
            InputDataRoadsAndLibraries[] oData = GetInputData(_sTestDataRootDir + "sample1_input.txt");
            long[] result = new long[oData.Length];
            for (int ii = 0; ii < oData.Length; ii++)
            {
                result[ii] = RoadsAndLibraries.roadsAndLibraries(oData[ii].numCities, oData[ii].costLibrary, oData[ii].costRoad, oData[ii].cityPairs);
            }
            long[] expected = new long[2] { 4, 12 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void sample2Test()
        {
            InputDataRoadsAndLibraries[] oData = GetInputData(_sTestDataRootDir + "sample2_input.txt");
            long[] result = new long[oData.Length];
            for (int ii = 0; ii < oData.Length; ii++)
            {
                result[ii] = RoadsAndLibraries.roadsAndLibraries(oData[ii].numCities, oData[ii].costLibrary, oData[ii].costRoad, oData[ii].cityPairs);
            }
            long[] expected = new long[1] { 15 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void hackerrank3Test()
        {
            InputDataRoadsAndLibraries[] oData = GetInputData(_sTestDataRootDir + "hackerrank3_input.txt");
            long[] result = new long[oData.Length];
            for (int ii = 0; ii < oData.Length; ii++)
            {
                result[ii] = RoadsAndLibraries.roadsAndLibraries(oData[ii].numCities, oData[ii].costLibrary, oData[ii].costRoad, oData[ii].cityPairs);
            }
            long[] expected = new long[10] { 7850257285, 6785201034, 813348013, 4211840970, 8610471142, 7263742960, 4331105640, 1226092626, 7288635830, 8276704464 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void hackerrank4Test()
        {
            InputDataRoadsAndLibraries[] oData = GetInputData(_sTestDataRootDir + "hackerrank4_input.txt");
            long[] result = new long[oData.Length];
            for (int ii = 0; ii < oData.Length; ii++)
            {
                result[ii] = RoadsAndLibraries.roadsAndLibraries(oData[ii].numCities, oData[ii].costLibrary, oData[ii].costRoad, oData[ii].cityPairs);
            }
            long[] expected = new long[10] { 9234981465, 5854508506, 7754252297, 8085193494, 9504556779, 8011172848, 9123393445, 7326423794, 8259748808, 8049633228 };

            CollectionAssert.AreEqual(expected, result);
        }

        private InputDataRoadsAndLibraries[] GetInputData(string sFileNameAndPath)
        {
            InputDataRoadsAndLibraries[] result;
            using (StreamReader filesm = new StreamReader(sFileNameAndPath))
            {
                int q = Convert.ToInt32(filesm.ReadLine());
                result = new InputDataRoadsAndLibraries[q];
                for (int qItr = 0; qItr < q; qItr++)
                {
                    string[] nmC_libC_road = filesm.ReadLine().Split(' ');

                    int n = Convert.ToInt32(nmC_libC_road[0]);

                    int m = Convert.ToInt32(nmC_libC_road[1]);

                    int c_lib = Convert.ToInt32(nmC_libC_road[2]);

                    int c_road = Convert.ToInt32(nmC_libC_road[3]);

                    int[][] cities = new int[m][];

                    for (int i = 0; i < m; i++)
                    {
                        cities[i] = Array.ConvertAll(filesm.ReadLine().Split(' '), c => Convert.ToInt32(c));
                    }
                    result[qItr] = new InputDataRoadsAndLibraries(c_road, c_lib, n, cities);
                }
            }
            return result;
        }
    }
}
