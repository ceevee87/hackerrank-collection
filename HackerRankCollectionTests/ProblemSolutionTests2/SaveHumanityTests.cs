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
    public class SaveHumanityTests
    {
        readonly string _sTestDataRootDir = string.Format(@"{0}\{1}\"
            , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
            , @"TestData\SaveHumanity");

        [Test]
        public void stringHashTest1()
        {
            SaveHumanity.InitPowers(5);
            SaveHumanity.BigPrime = 536870923;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(3752127, SaveHumanity.CalculateStringHash("hello"));
                Assert.AreEqual(2504317, SaveHumanity.CalculateStringHash("ellow"));
                Assert.AreEqual(5705377, SaveHumanity.CalculateStringHash("llowo"));
                Assert.AreEqual(5763308, SaveHumanity.CalculateStringHash("lowor"));
                Assert.AreEqual(7269508, SaveHumanity.CalculateStringHash("oworl"));
                Assert.AreEqual(10786572, SaveHumanity.CalculateStringHash("world"));
            });
        }

        [Test]
        public void rollingStringHashTest1()
        {
            SaveHumanity.InitPowers(5);
            SaveHumanity.BigPrime = 536870923;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2504317,  SaveHumanity.CalculateNewRollingHash(3752127, "hellow", 4));
                Assert.AreEqual(5705377,  SaveHumanity.CalculateNewRollingHash(2504317, "ellowo", 4));
                Assert.AreEqual(5763308,  SaveHumanity.CalculateNewRollingHash(5705377, "llowor",4));
                Assert.AreEqual(7269508,  SaveHumanity.CalculateNewRollingHash(5763308, "loworl",4));
                Assert.AreEqual(10786572, SaveHumanity.CalculateNewRollingHash(7269508, "oworld",4));
            });
        }

        [Test]
        public void HackerrankTest4()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "hackerrank4_input.txt");

            List<string[]> result = new List<string[]>();
            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrank4_answer.txt", oData.Count);

            foreach (string[] arr in oData)
            {
                int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                if (r[0] == -1)
                {
                    result.Add(new string[1] { "No Match!" });
                }
                else
                {
                    result.Add(r.Select(i => i.ToString()).ToArray());
                }
            }
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void sampleInput1()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "sampleinput01_input.txt");

            List<string[]> expected = new List<string[]>();

            expected.Add(new string[2] { "1", "2" });
            expected.Add(new string[1] { "No Match!" });
            expected.Add(new string[2] { "0", "2" });

            int testCounter = 0;
            Assert.Multiple(() =>
            {

                foreach (string[] arr in oData)
                {
                    int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                    if (r[0] == -1)
                    {
                        CollectionAssert.AreEqual(expected.ElementAt(testCounter), new string[1] { "No Match!" });
                    }
                    else
                    {
                        CollectionAssert.AreEqual(expected.ElementAt(testCounter), r.Select(i => i.ToString()).ToArray());
                    }
                    testCounter++;
                }
            });
        }

        [Test]
        public void sampleInput2()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "sampleinput02_input.txt");

            List<string[]> result = new List<string[]>();
            List<string[]> expected = new List<string[]>();

            expected.Add(new string[2] { "1", "3" });
            expected.Add(new string[2] { "2", "6" });
            expected.Add(new string[3] { "0", "1", "5" });

            foreach (string[] arr in oData)
            {

                int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                if (r[0] == -1)
                {
                    result.Add(new string[1] { "No Match!" });
                }
                else
                {
                    result.Add(r.Select(i => i.ToString()).ToArray());
                }
            }
            CollectionAssert.AreEqual(expected, result);
        }

        private List<string[]> GetInputData(string inFile)
        {
            List<string[]> res = new List<string[]>();

            using (StreamReader fsr = new StreamReader(inFile))
            {
                int t = Convert.ToInt32(fsr.ReadLine());

                for (int tItr = 0; tItr < t; tItr++)
                {
                    string[] pv = fsr.ReadLine().Split(' ');
                    res.Add(pv);
                }
            }
            return res;
        }

        private List<string[]> GetAnswerData(string ansFile, int numResults)
        {
            List<string[]> res = new List<string[]>();

            using (StreamReader fsr = new StreamReader(ansFile))
            {
                for (int ii = 0; ii < numResults; ii++)
                {
                    string line = fsr.ReadLine();
                    if (line.Equals("No Match!"))
                    {
                        res.Add(new string[1] { "No Match!" });
                        continue;
                    }
                    res.Add(line.Split(' '));
                }
            }
            return res;
        }
    }
}
