using HackerRankCollection.ProblemSolutions;
using System.IO;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class ContactsTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\Contacts");

        [Test]
        public void Test1()
        {
            string[][] aQueries = new string[4][];
            aQueries[0] = new string[2] { "add", "hack" };
            aQueries[1] = new string[2] { "add", "hackerrank" };
            aQueries[2] = new string[2] { "find", "hac" };
            aQueries[3] = new string[2] { "find", "hak" };

            CollectionAssert.AreEqual(Contacts.contacts(aQueries), new int[] { 2, 0 });
        }

        [Test]
        public void Test2()
        {
            string[][] aQueries = new string[11][];
            aQueries[0] = new string[2] { "add", "s" };
            aQueries[1] = new string[2] { "add", "ss" };
            aQueries[2] = new string[2] { "add", "sss" };
            aQueries[3] = new string[2] { "add", "ssss" };
            aQueries[4] = new string[2] { "add", "sssss" };
            aQueries[5] = new string[2] { "find", "s" };
            aQueries[6] = new string[2] { "find", "ss" };
            aQueries[7] = new string[2] { "find", "sss" };
            aQueries[8] = new string[2] { "find", "ssss" };
            aQueries[9] = new string[2] { "find", "sssss" };
            aQueries[10] = new string[2] { "find", "ssssss" };

            int[] aExpected = new int[6] { 5, 4, 3, 2, 1, 0 };
            CollectionAssert.AreEqual(Contacts.contacts(aQueries), aExpected);
        }

        // test passes below but runs too slow for HackerRank
        // it took about 1 minute on my computer.
        [Test]
        public void Test2HackerRank()
        {
            string[][] aQueries = GetInputQueryOperations(_sTestDataRootDir + "contacts.testcase2.input.txt");
            int[] aExpected = GetExpectedResultsFromFile(_sTestDataRootDir + "contacts.testcase2.output.txt");
            CollectionAssert.AreEqual(Contacts.contacts(aQueries), aExpected);

        }
        // test passes below but runs too slow for HackerRank
        // it took about 6 minutes on my computer.
        [Test]
        public void Test9HackerRank()
        {
            string[][] aQueries = GetInputQueryOperations(_sTestDataRootDir + "contacts.testcase9.input.txt");
            int[] aExpected = GetExpectedResultsFromFile(_sTestDataRootDir + "contacts.testcase9.output.txt");
            CollectionAssert.AreEqual(Contacts.contacts(aQueries), aExpected);

        }

        private string[][] GetInputQueryOperations(string inFile)
        {
            string[][] queries;
            using (StreamReader file = new StreamReader(inFile))
            {
                int iNumOperations = Convert.ToInt32(file.ReadLine());
                queries = new string[iNumOperations][];

                for (int ii = 0; ii < iNumOperations; ii++)
                {
                    queries[ii] = file.ReadLine().Split(' ');
                }
            }
            return queries;
        }

        private int[] GetExpectedResultsFromFile(string sFileName)
        {
            List<int> lAnswers = new List<int>();
            string line;
            using (StreamReader file = new StreamReader(sFileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    lAnswers.Add(Convert.ToInt32(line));
                }
            }
            return lAnswers.ToArray();
        }
    }
}
