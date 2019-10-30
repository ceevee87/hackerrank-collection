using HackerRankCollection.ProblemSolutions2;
using NUnit.Framework;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests2
{
    [TestFixture]
    public class NoPrefixSetTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\NoPrefixSet");


        [Test]
        public void hackerrank16Test()
        {
            string[] oData = GetInputData(_sTestDataRootDir + "hackerrank16_input.txt");
            PrefixCheckResult result = NoPrefixSet.DoBadPrefixCheck(oData);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(false, result._result);
                Assert.AreEqual("jiechedejbbeaabeef", result._word);
            });

        }

        [Test]
        public void hackerrank21Test()
        {
            string[] oData = GetInputData(_sTestDataRootDir + "hackerrank21_input.txt");
            PrefixCheckResult result = NoPrefixSet.DoBadPrefixCheck(oData);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(false, result._result);
                Assert.AreEqual("aabcde", result._word);
            });

        }

        [Test]
        public void hackerrank22Test()
        {
            string[] oData = GetInputData(_sTestDataRootDir + "hackerrank22_input.txt");
            PrefixCheckResult result = NoPrefixSet.DoBadPrefixCheck(oData);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(false, result._result);
                Assert.AreEqual("aacghgh", result._word);
            });

        }

        [Test]
        public void hackerrank41Test()
        {
            string[] oData = GetInputData(_sTestDataRootDir + "hackerrank41_input.txt");
            PrefixCheckResult result = NoPrefixSet.DoBadPrefixCheck(oData);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, result._result);
                Assert.IsTrue(true);
            });

        }

        private static string[] GetInputData(string inFile)
        {
            string[] result;
            using (StreamReader fsr = new StreamReader(inFile))
            {
                int k = Convert.ToInt32(fsr.ReadLine());
                result = new string[k];
                for (int ii = 0; ii < k; ii++)
                {
                    result[ii] = fsr.ReadLine();
                }
            }
            return result;
        }
    }
}
