using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class FindTheRunningMedianTests
    {
        private string _sTestDataRootDir = @"..\..\TestData\FindTheRunningMedian\";

        [TestMethod]
        public void SampleTestA()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "sampleA_input.txt");
            double[] result = FindTheRunningMedian.runningMedian(arr);
            double[] expected = new double[] { 12.0, 8.0, 5.0, 4.5, 5.0, 6.0 };
            CollectionAssert.AreEqual(expected, result);
        }

        private int[] GetInputArray(string inFile)
        {
            // zero error catching here ... make sure your input is legit
            int[] arr ;
            using (StreamReader file = new StreamReader(inFile))
            {
                int n = Convert.ToInt32(file.ReadLine());
                arr = new int[n];
                string line;
                int ii = 0;
                while ((line = file.ReadLine()) != null && ii < n)
                {
                    arr[ii++] = Convert.ToInt32(line);
                }
            }
            return arr;
        }

    }
}
