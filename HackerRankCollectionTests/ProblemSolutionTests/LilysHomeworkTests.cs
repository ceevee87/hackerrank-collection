using HackerRankCollection.ProblemSolutions;
using System;
using System.IO;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    //[TestFixture]
    class LilysHomeworkTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
            , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
            , @"TestData\LilyHomeworkTests");

        [Test]
        public void ProblemExplanationTest()
        {
            int[] arr = new int[] { 7, 15, 12, 3};
            var res = LilysHomework.lilysHomework(arr);
            Assert.AreEqual(2, res);
        }

        [Test]
        public void SolutionExampleATest()
        {
            int[] arr = new int[] { 2, 5, 3, 1};
            var res = LilysHomework.lilysHomework(arr);
            Assert.AreEqual(2, res);
        }

        [Test]
        public void HackerRankTest3()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "testcase3_input.txt");
            int result = LilysHomework.lilysHomework(arr); ;
            Assert.AreEqual(result, 99985);
        }

        [Test]
        public void HackerRankTest7()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "testcase7_input.txt");
            int result = LilysHomework.lilysHomework(arr); ;
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void HackerRankTest8()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "testcase8_input.txt");
            int result = LilysHomework.lilysHomework(arr); ;
            Assert.AreEqual(result, 100);
        }

        [Test]
        public void HackerRankTest9()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "testcase9_input.txt");
            int result = LilysHomework.lilysHomework(arr); ;
            Assert.AreEqual(result, 100);
        }

        [Test]
        public void HackerRankTest11()
        {
            int[] arr = GetInputArray(_sTestDataRootDir + "testcase11_input.txt");
            int result = LilysHomework.lilysHomework(arr); ;
            Assert.AreEqual(result, 2);
        }

        private int[] GetInputArray(string inFile)
        {
            // zero error catching here ... make sure your input is legit
            int[] arr;
            using (StreamReader file = new StreamReader(inFile))
            {
                int n = Convert.ToInt32(file.ReadLine());
                arr = Array.ConvertAll(file.ReadLine().Split(' '), a => Convert.ToInt32(a));
            }
            return arr;
        }
    }
}
