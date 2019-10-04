﻿using HackerRankCollection.ProblemSolutions;
using System;
using System.IO;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class JesseAndCookiesTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\JesseAndCookies");

        private class JesseAndCookiesInputData
        {
            public readonly int[] aCookies;
            public readonly int iMinSweetness;

            public JesseAndCookiesInputData(int k, int[] cookiedata)
            {
                aCookies = cookiedata;
                iMinSweetness = k;
            }
        }

        [Test]
        public void HeapTest1()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "heap_test1_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void Test1()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "sample1_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result,2);
        }

        [Test]
        public void ImpossibleTest1()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "impossible1_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void BasicTest1()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "basic1_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void HackerRankTest11()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "testcase11_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void HackerRankTest18()
        {
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "testcase18_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, 99999);
        }

        [Test]
        public void HackerRankTest15()
        {
            // fails HackerRank performance test
            // results are correct, though
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "testcase15_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, 98189);
        }

        [Test]
        public void HackerRankTest21()
        {
            // fails HackerRank performance test
            // results are correct, though
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "testcase21_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, 615271);
        }

        [Test]
        public void HackerRankTest22()
        {
            // fails HackerRank performance test
            // results are correct, though
            JesseAndCookiesInputData x = GetCookieSweetnessDataFromFile(_sTestDataRootDir + "testcase22_input.txt");
            int result = JesseAndCookies.cookies(x.iMinSweetness, x.aCookies);
            Assert.AreEqual(result, 800471);
        }

        private JesseAndCookiesInputData GetCookieSweetnessDataFromFile(string inFile)
        {
            // zero error catching here ... make sure your input is legit
            int[] cookiedata;
            int numcookies;
            int minsweetness;
            using (StreamReader file = new StreamReader(inFile))
            {
                string[] nk = file.ReadLine().Split(' ');
                numcookies = Convert.ToInt32(nk[0]);
                minsweetness = Convert.ToInt32(nk[1]);

                cookiedata = Array.ConvertAll(file.ReadLine().Split(' '), a => Convert.ToInt32(a));
            }
            return new JesseAndCookiesInputData(minsweetness, cookiedata);
        }
    }
}
