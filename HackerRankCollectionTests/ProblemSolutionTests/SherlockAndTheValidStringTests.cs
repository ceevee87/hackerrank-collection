using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class SherlockAndTheValidStringTests
    {
        private string _sTestDataRootDir = @"..\..\TestData\SherlockAndTheValidString\";

        [TestMethod]
        public void FailIsValid()
        {
            string res = SherlockAndTheValidString.isValid("ebbccdda");
            Assert.AreEqual("NO", res);
        }

        [DataRow("aaaaaaaaaaaabbbcccddd")]
        [DataRow("aaaaabcdefg")]
        [DataTestMethod]
        public void Trickey1Test(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("NO", res);
        }


        [DataRow("ebbccdda")]
        [DataRow("abbcccdddd")]
        [DataRow("cccbbaaz")]
        [DataRow("aaaabbcc")]   // HackerRank test 3
        [DataRow("aaaaabc")]    // HackerRank test 5
        [DataTestMethod]
        public void BigStringIsNotValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("NO", res);
        }

        [DataRow("abbccdd")]
        [DataRow("bbccdda")]
        [DataTestMethod]
        public void RemoveLastCharTest(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }


        [DataRow("a")]
        [DataRow("bb")]
        [DataRow("ccccc")]
        [DataTestMethod]
        public void BigSameCharStringIsValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }

        [DataRow("bcdaa")]
        [DataRow("aabcd")]
        [DataRow("abcda")]
        [DataRow("zzzaabbcc")]
        [DataRow("abcdef")]
        [DataRow("xxabcdef")]
        [DataRow("aaaabbbcccddd")]
        [DataTestMethod]
        public void BigStringIsValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }

        // 
        [TestMethod]
        public void HackerRankTest4()
        {
            string res = SherlockAndTheValidString.isValid("aabbc");
            Assert.AreEqual("YES", res);
        }

        [TestMethod]
        public void HackerRankTest7()
        {
            // input string is 1000 chars long
            string s = GetInputString(_sTestDataRootDir + "testcase7_input.txt");
            string result = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual(result, "YES");
        }

        [TestMethod]
        public void HackerRankTest13()
        {
            // input string is 10K chars long
            string s = GetInputString(_sTestDataRootDir + "testcase13_input.txt");
            string result = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual(result, "YES");
        }

        [TestMethod]
        public void HackerRankTest16()
        {
            string res = SherlockAndTheValidString.isValid("abbac");
            Assert.AreEqual("YES", res);
        }

        private string GetInputString(string inFile)
        {
            // zero error catching here ... make sure your input is legit
            string result;
            using (StreamReader file = new StreamReader(inFile))
            {
                result = file.ReadLine();
            }
            return result;
        }
    }
}
