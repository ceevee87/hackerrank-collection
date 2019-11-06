using HackerRankCollection.ProblemSolutions2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void doHashVariances()
        {
            string s = "virus";
            char variantChar = 'a';

            SaveHumanity.InitPowers(5);
            SaveHumanity.BigPrime = 536870923;

            for (int jj = s.Length - 1; jj >= 0; jj--)
            {
                char[] sArr = s.ToArray();
                for (int ii = 0; ii < 26; ii++)
                {
                    sArr[jj] = (char)(variantChar + ii);
                    string foo = new string(sArr);
                    Debug.WriteLine(string.Format("variant char: {0}, hash = {1}", foo, SaveHumanity.CalculateStringHash(foo)));
                }
            }
        }


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
                Assert.AreEqual(2504317, SaveHumanity.CalculateNewRollingHash(3752127, "hellow", 4));
                Assert.AreEqual(5705377, SaveHumanity.CalculateNewRollingHash(2504317, "ellowo", 4));
                Assert.AreEqual(5763308, SaveHumanity.CalculateNewRollingHash(5705377, "llowor", 4));
                Assert.AreEqual(7269508, SaveHumanity.CalculateNewRollingHash(5763308, "loworl", 4));
                Assert.AreEqual(10786572, SaveHumanity.CalculateNewRollingHash(7269508, "oworld", 4));
            });
        }

        [Test]
        public void sampleInputX_()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "sampleinputX_input.txt");

            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrankX_answer.txt", oData.Count);

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
        public void HackerrankTest2()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "hackerrank2_input.txt");

            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrank2_answer.txt", oData.Count);

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
        public void HackerrankTest3()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "hackerrank3_input.txt");

            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrank3_answer.txt", oData.Count);

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
        public void HackerrankTest8()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "hackerrank8_input.txt");

            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrank8_answer.txt", oData.Count);

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
        public void HackerrankTest4()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "hackerrank4_input.txt");

            List<string[]> result = new List<string[]>();
            List<string[]> expected = GetAnswerData(_sTestDataRootDir + "hackerrank4_answer.txt", oData.Count);


            int testCounter = 0;
            Stopwatch sw = new Stopwatch();
            foreach (string[] arr in oData)
            {
                Debug.WriteLine(string.Format("Test number: {0}", testCounter + 1));
                Debug.WriteLine(string.Format("Size of human DNA strand: {0}", arr[0].Length));
                Debug.WriteLine(string.Format("Size of virus DNA strand: {0}", arr[1].Length));
                Debug.WriteLine(string.Format("Ratio of virus length to human dna length: {0}", (float)arr[1].Length / (float)arr[0].Length));
                SaveHumanity.ToleranceCheckCounter = 0;
                SaveHumanity.EqualityCheckCounter = 0;

                sw.Start();
                int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                if (r[0] == -1)
                {
                    result.Add(new string[1] { "No Match!" });
                }
                else
                {
                    result.Add(r.Select(i => i.ToString()).ToArray());
                }
                sw.Stop();
                string dbgResult = (r[0] == -1) ? "No Match!" : string.Format("{0} locations found.", r.Length);
                Debug.WriteLine(string.Format("Number of checks done because hash was within tolerance: {0}", SaveHumanity.ToleranceCheckCounter));
                Debug.WriteLine(string.Format("Number of equality checks performed: {0}", SaveHumanity.EqualityCheckCounter));
                Debug.WriteLine(dbgResult);
                Debug.WriteLine(string.Format("Time elapsed: {0} seconds", (float)sw.ElapsedMilliseconds / 1000.0));
                Debug.WriteLine("");
                sw.Reset();
                testCounter++;
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
