using HackerRankCollection.ProblemSolutions2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollectionTests.ProblemSolutionTests2
{
    [TestFixture]
    public class MinimumAverageWaitTimeTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\MinimumAverageWaitingTime");

        [Test]
        public void SampleTest0()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "sample0_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 9;
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void HackerrankTest0()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "hackerrank0_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 1418670047;
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void HackerrankTest1()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "hackerrank1_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 8485548331;
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void HackerrankTest2()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "hackerrank2_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 6667863382;
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void HackerrankTest7()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "hackerrank7_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 8323528195457;
            Assert.AreEqual(expected, result);

        }

        // performance test
        [Test]
        public void HackerrankTest9()
        {
            int[][] oData = GetInputData(_sTestDataRootDir + "hackerrank9_input.txt");
            long result = MinimumAverageWaitTime.minimumAverage(oData);

            long expected = 16631801980531;
            Assert.AreEqual(expected, result);

        }

        private int[][] GetInputData(string inFile)
        {
            int[][] customers;
            using (StreamReader fsr = new StreamReader(inFile))
            {
                int n = Convert.ToInt32(fsr.ReadLine());
                customers = new int[n][];
                for (int rowcnt = 0; rowcnt < n; rowcnt++)
                {
                    customers[rowcnt] = Array.ConvertAll(fsr.ReadLine().Split(' '), r => Convert.ToInt32(r));
                }
            }
            return customers;
        }
    }
}
