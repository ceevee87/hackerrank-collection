using HackerRankCollection.ProblemSolutions;
using NUnit.Framework;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class JourneyToTheMoonTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\JourneyToTheMoon");

        internal class TestInputData
        {
            public int numAstronauts { get; set; }
            public int[][] astronautPairData { get; set; }
        }

        [Test]
        public void SampleTest1()
        {
            TestInputData oData = BadVibes(_sTestDataRootDir + "sample1_input.txt");
            int result = JourneyToTheMoon.journeyToMoon(oData.numAstronauts, oData.astronautPairData);
            int expected = 5;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void SampleTest2()
        {
            TestInputData oData = BadVibes(_sTestDataRootDir + "sample2_input.txt");
            int result = JourneyToTheMoon.journeyToMoon(oData.numAstronauts, oData.astronautPairData);
            int expected = 5;
            Assert.AreEqual(result, expected);
        }

        private TestInputData BadVibes(string sFileNameAndPath)
        {
            int[][] astronaut;
            int n;
            using (StreamReader fsr = new StreamReader(sFileNameAndPath))
            {
                string[] np = fsr.ReadLine().Split(' ');

                n = Convert.ToInt32(np[0]);

                int p = Convert.ToInt32(np[1]);

                astronaut = new int[p][];

                for (int i = 0; i < p; i++)
                {
                    astronaut[i] = Array.ConvertAll(fsr.ReadLine().Split(' '), astronautTemp => Convert.ToInt32(astronautTemp));
                }

            }
            return new TestInputData { numAstronauts = n, astronautPairData = astronaut }; 
        }
    }
}
