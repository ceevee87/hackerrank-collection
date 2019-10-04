using HackerRankCollection.ProblemSolutions;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class QHeap1Tests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    ,@"TestData\QHeap1");

        [Test]
        public void SampleATest()
        {
            string[] queries = new string[] { "1 4", "1 9", "3", "2 4", "3" };
            int[] result = QHeap1.ProcessQueries(queries);
            int[] expected = new int[] { 4, 9 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest14()
        {
            string[] queries = GetInputData(_sTestDataRootDir + "hackerrank14_input.txt");
            int[] expected = GetResultAnswers(_sTestDataRootDir + "hackerrank14_answer.txt");
            int[] result = QHeap1.ProcessQueries(queries);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankTest16()
        {
            string[] queries = GetInputData(_sTestDataRootDir + "hackerrank16_input.txt");
            int[] expected = GetResultAnswers(_sTestDataRootDir + "hackerrank16_answer.txt");
            int[] result = QHeap1.ProcessQueries(queries);
            CollectionAssert.AreEqual(expected, result);
        }

        private static string[] GetInputData(string inFile)
        {
            string[] queries;
            using (StreamReader file = new StreamReader(inFile))
            {
                int k = Convert.ToInt32(file.ReadLine());
                queries = new string[k];
                for (int ii = 0; ii < k; ii++)
                {
                    queries[ii] = file.ReadLine();
                }
            }
            return queries;
        }

        private static int[] GetResultAnswers(string inFile)
        {
            List<int> answers = new List<int>();
            using (StreamReader file = new StreamReader(inFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    answers.Add(Convert.ToInt32(line));
                }
            }
            return answers.ToArray();
        }

    }
}
