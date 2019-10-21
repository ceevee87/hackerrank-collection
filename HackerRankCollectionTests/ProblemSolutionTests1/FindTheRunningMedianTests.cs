﻿using HackerRankCollection.ProblemSolutions;
using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class FindTheRunningMedianTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\FindTheRunningMedian");

        [Test]
        public void SampleTestA()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "sampleA_input.txt");
            double[] result = FindTheRunningMedian.runningMedian(arr);
            double[] expected = new double[] { 12.0, 8.0, 5.0, 4.5, 5.0, 6.0 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void SampleTestB()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "sampleB_input.txt");
            double[] result = FindTheRunningMedian.runningMedian(arr);
            double[] expected = new double[] { 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest1()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank1_input.txt");
            double[] expected = GetAnswerArray(_sTestDataRootDir + "hackerrank1_answer.txt", arr.Length);

            double[] result = FindTheRunningMedian.runningMedian(arr);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest1Abbrev()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank1_abbrev_input.txt");
            double[] result = FindTheRunningMedian.runningMedian(arr);

            string[] res3 = result.Select(v => String.Format("{0:#.0}", v)).ToArray();

            double[] expected = new double[] { 94455.0, 57505.0, 20555.0, 36840.0 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest2()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank2_input.txt");
            double[] expected = GetAnswerArray(_sTestDataRootDir + "hackerrank2_answer.txt", arr.Length);

            double[] result = FindTheRunningMedian.runningMedian(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest3()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank3_input.txt");
            double[] expected = GetAnswerArray(_sTestDataRootDir + "hackerrank3_answer.txt", arr.Length);

            double[] result = FindTheRunningMedian.runningMedian(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest4()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank4_input.txt");
            double[] expected = GetAnswerArray(_sTestDataRootDir + "hackerrank4_answer.txt", arr.Length);

            double[] result = FindTheRunningMedian.runningMedian(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest5()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "hackerrank5_input.txt");
            double[] expected = GetAnswerArray(_sTestDataRootDir + "hackerrank5_answer.txt", arr.Length);

            double[] result = FindTheRunningMedian.runningMedian(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        private int[] GetInputArray(string inFile)
        {
            // zero error catching here ... make sure your input is legit
            int[] arr;
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

        private double[] GetAnswerArray(string inFile, int n)
        {
            // zero error catching here ... make sure your input is legit
            double[] arr = new double[n];
            using (StreamReader file = new StreamReader(inFile))
            {
                string line;
                int ii = 0;
                while ((line = file.ReadLine()) != null && ii < n)
                {
                    arr[ii++] = Convert.ToDouble(line);
                }
            }
            return arr;
        }

    }
}