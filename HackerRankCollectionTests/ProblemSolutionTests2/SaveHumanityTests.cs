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


        [TestCase(3)]
        [TestCase(4)]
        [TestCase(8)]
        public void PerformanceHackerrankTests(int testNum)
        {
            string inFile = string.Format("{0}hackerrank{1}_input.txt", _sTestDataRootDir, testNum);
            List<string[]> oData = GetInputData(inFile);

            Assert.Multiple(() =>
            {

                int testCounter = 0;
                long elapsedTime = 0;
                foreach (string[] arr in oData)
                {
                    Stopwatch swInitPowers = new Stopwatch();
                    Stopwatch swCalcRollingHash = new Stopwatch();
                    Stopwatch swCalcVirusHash = new Stopwatch();

                    string p = arr[0];
                    string v = arr[1];

                    swInitPowers.Start();
                    SaveHumanity.InitPowers(v.Length);
                    swInitPowers.Stop();

                    SaveHumanity.BigPrime = 536870923;

                    swCalcVirusHash.Start();
                    long rollingHash = SaveHumanity.CalculateStringHash(p.Substring(0, v.Length));
                    swCalcVirusHash.Stop();

                    swCalcRollingHash.Start();
                    for (int ii = 0; ii <= p.Length - v.Length; ii++)
                    {
                        string sub = p.Substring(ii, v.Length);
                        if (ii < p.Length - v.Length)
                        {
                            rollingHash = SaveHumanity.CalculateNewRollingHash(rollingHash, p.Substring(ii, v.Length + 1));
                        }
                    }
                    swCalcRollingHash.Stop();

                    Debug.WriteLine(string.Format("Test case {0} : InitPowers (ms): {1}", testCounter, swInitPowers.ElapsedMilliseconds));
                    Debug.WriteLine(string.Format("Test case {0} : Calc Virus Hash (ms): {1}", testCounter, swCalcVirusHash.ElapsedMilliseconds));
                    Debug.WriteLine(string.Format("Test case {0} : Total rollinghash calc time (s): {1}", testCounter, (float)swCalcRollingHash.ElapsedMilliseconds / 1000.0));
                    Debug.WriteLine("");

                    testCounter++;

                    elapsedTime = swCalcRollingHash.ElapsedMilliseconds;
                }
                Assert.IsTrue(elapsedTime <= 10000);
            });
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(8)]
        public void RollingHashHackerrankTests(int testNum)
        {
            string inFile = string.Format("{0}hackerrank{1}_input.txt", _sTestDataRootDir, testNum);
            List<string[]> oData = GetInputData(inFile);

            int testCounter = 0;

            Assert.Multiple(() =>
            {
                foreach (string[] arr in oData)
                {
                    int mismatchHashCount = 0;

                    string p = arr[0];
                    string v = arr[1];

                    SaveHumanity.InitPowers(v.Length);
                    SaveHumanity.BigPrime = 536870923;

                    long rollingHash = SaveHumanity.CalculateStringHash(p.Substring(0, v.Length));

                    Stopwatch swCalcHash = new Stopwatch();
                    swCalcHash.Start();
                    for (int ii = 0; ii <= p.Length - v.Length; ii++)
                    {
                        string sub = p.Substring(ii, v.Length);

                        if (!swCalcHash.IsRunning) swCalcHash.Start();
                        long subHash = SaveHumanity.CalculateStringHash(sub);
                        swCalcHash.Stop();

                        if (subHash != rollingHash)
                        {
                            mismatchHashCount++;
                        }
                        if (ii < p.Length - v.Length)
                        {
                            rollingHash = SaveHumanity.CalculateNewRollingHash(rollingHash, p.Substring(ii, v.Length + 1));
                        }
                    }

                    Debug.WriteLine("");

                    testCounter++;
                    Debug.WriteLine(string.Format("Test case {0} : Total hash calc time (s): {1}", testCounter, (float)swCalcHash.ElapsedMilliseconds / 1000.0));
                    Debug.WriteLine("");
                    Assert.AreEqual(0, mismatchHashCount, string.Format("Test case {0} : found {1} instances of the rolling hash not matching the real hash", testCounter, mismatchHashCount));
                }
            });
        }



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
                Assert.AreEqual(49376607, SaveHumanity.CalculateStringHash("hello"), "string hash 1 is messed up");
                Assert.AreEqual(48128797, SaveHumanity.CalculateStringHash("ellow"), "string hash 2 is messed up");
                Assert.AreEqual(51329857, SaveHumanity.CalculateStringHash("llowo"), "string hash 3 is messed up");
                Assert.AreEqual(51387788, SaveHumanity.CalculateStringHash("lowor"), "string hash 4 is messed up");
                Assert.AreEqual(52893988, SaveHumanity.CalculateStringHash("oworl"), "string hash 5 is messed up");
                Assert.AreEqual(56411052, SaveHumanity.CalculateStringHash("world"), "string hash 6 is messed up");
            });
        }


        [Test]
        public void stringHashvRollingTest1()
        {
            int sLength = 50;
            SaveHumanity.InitPowers(sLength);
            SaveHumanity.BigPrime = 536870923;

            StringBuilder s1 = new StringBuilder(sLength);

            for (int ii = 0; ii < sLength; ii++)
            {
                s1.Append('a');
            }
            StringBuilder s2 = new StringBuilder(s1.ToString());
            s2.Append('z');

            long s1HashCalculated = SaveHumanity.CalculateStringHash(s1.ToString());
            s1[s1.Length - 1] = 'z';
            long s1ShiftedHashCalculated = SaveHumanity.CalculateStringHash(s1.ToString());

            long s2ShiftedHashCalculated = SaveHumanity.CalculateNewRollingHash(s1HashCalculated, s2.ToString());

            Assert.Multiple(() =>
            {
                Assert.AreEqual(s1ShiftedHashCalculated, s2ShiftedHashCalculated);
            });
        }

        [Test]
        public void rollingStringHashTest1()
        {
            SaveHumanity.InitPowers(5);
            SaveHumanity.BigPrime = 536870923;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(48128797, SaveHumanity.CalculateNewRollingHash(SaveHumanity.CalculateStringHash("hello"), "hellow"), "hash 1 is jacked.");
                Assert.AreEqual(51329857, SaveHumanity.CalculateNewRollingHash(48128797, "ellowo"), "hash 2 is jacked.");
                Assert.AreEqual(51387788, SaveHumanity.CalculateNewRollingHash(51329857, "llowor"), "hash 3 is jacked.");
                Assert.AreEqual(52893988, SaveHumanity.CalculateNewRollingHash(51387788, "loworl"), "hash 4 is jacked.");
                Assert.AreEqual(56411052, SaveHumanity.CalculateNewRollingHash(52893988, "oworld"), "hash 5 is jacked.");
            });
        }


        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(8)]
        public void HackerrankTests(int testNum)
        {
            string inFile = string.Format("{0}hackerrank{1}_input.txt", _sTestDataRootDir, testNum);
            List<string[]> oData = GetInputData(inFile);

            string ansFile = string.Format("{0}hackerrank{1}_answer.txt", _sTestDataRootDir, testNum);
            List<string[]> expected = GetAnswerData(ansFile, oData.Count);

            int testCounter = 0;
            Stopwatch sw = new Stopwatch();
            Assert.Multiple(() =>
            {
                foreach (string[] arr in oData)
                {
                    Debug.WriteLine(string.Format("Test number: {0}", testCounter + 1));
                    Debug.WriteLine(string.Format("Size of human DNA strand: {0}", arr[0].Length));
                    Debug.WriteLine(string.Format("Size of virus DNA strand: {0}", arr[1].Length));
                    Debug.WriteLine(string.Format("Ratio of virus length to human dna length: {0}", (float)arr[1].Length / (float)arr[0].Length));
                    SaveHumanity.ToleranceCheckCounter = 0;
                    SaveHumanity.EqualityCheckCounter = 0;

                    sw.Start();
                    string sFailMsg = string.Format("Failed on sub-test {0}", testCounter + 1);

                    int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                    if (r[0] == -1)
                    {
                        CollectionAssert.AreEqual(expected.ElementAt(testCounter), new string[1] { "No Match!" }, sFailMsg);
                    }
                    else
                    {
                        CollectionAssert.AreEqual(expected.ElementAt(testCounter), r.Select(i => i.ToString()).ToArray(), sFailMsg);

                    }
                    sw.Stop();

                    string dbgResult = (r[0] == -1) ? "No Match!" : string.Format("{0} locations found.", r.Length);
                    Debug.WriteLine(string.Format("Number of checks done because hash was within tolerance: {0}", SaveHumanity.ToleranceCheckCounter));
                    Debug.WriteLine(string.Format("Number of equality checks performed: {0}", SaveHumanity.EqualityCheckCounter));
                    Debug.WriteLine(dbgResult);
                    Debug.WriteLine(string.Format("Time elapsed: {0} seconds", (float)sw.ElapsedMilliseconds / 1000.0));
                    Debug.WriteLine("");
                    testCounter++;

                    sw.Reset();
                }
            });
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
