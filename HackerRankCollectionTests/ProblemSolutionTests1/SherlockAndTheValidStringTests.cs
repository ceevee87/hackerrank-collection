using HackerRankCollection.ProblemSolutions;
using System.IO;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class SherlockAndTheValidStringTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                        , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                        , @"TestData\SherlockAndTheValidString");

        [Test]
        public void FailIsValid()
        {
            string res = SherlockAndTheValidString.isValid("ebbccdda");
            Assert.AreEqual("NO", res);
        }

        [TestCase("aaaaaaaaaaaabbbcccddd")]
        [TestCase("aaaaabcdefg")]
        // [DataTestMethod]
        public void Trickey1Test(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("NO", res);
        }


        [TestCase("ebbccdda")]
        [TestCase("abbcccdddd")]
        [TestCase("cccbbaaz")]
        [TestCase("aaaabbcc")]   // HackerRank test 3
        [TestCase("aaaaabc")]    // HackerRank test 5
        // [DataTestMethod]
        public void BigStringIsNotValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("NO", res);
        }

        [TestCase("abbccdd")]
        [TestCase("bbccdda")]
        // [DataTestMethod]
        public void RemoveLastCharTest(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }


        [TestCase("a")]
        [TestCase("bb")]
        [TestCase("ccccc")]
        // [DataTestMethod]
        public void BigSameCharStringIsValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }

        [TestCase("bcdaa")]
        [TestCase("aabcd")]
        [TestCase("abcda")]
        [TestCase("zzzaabbcc")]
        [TestCase("abcdef")]
        [TestCase("xxabcdef")]
        [TestCase("aaaabbbcccddd")]
        // [DataTestMethod]
        public void BigStringIsValid(string s)
        {
            string res = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual("YES", res);
        }

        // 
        [Test]
        public void HackerRankTest4()
        {
            string res = SherlockAndTheValidString.isValid("aabbc");
            Assert.AreEqual("YES", res);
        }

        [Test]
        public void HackerRankTest7()
        {
            // input string is 1000 chars long
            string s = GetInputString(_sTestDataRootDir + "testcase7_input.txt");
            string result = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual(result, "YES");
        }

        [Test]
        public void HackerRankTest13()
        {
            // input string is 10K chars long
            string s = GetInputString(_sTestDataRootDir + "testcase13_input.txt");
            string result = SherlockAndTheValidString.isValid(s);
            Assert.AreEqual(result, "YES");
        }

        [Test]
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
