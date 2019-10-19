using HackerRankCollection.ProblemSolutions;
using NUnit.Framework;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class HackerlandRadioTransmittersTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\HackerlandRadioTransmitters");

        internal class HackerlandRadioTransmitterInputData
        {
            public int[] _homeLocations;
            public int _transmitterDistance;

            public HackerlandRadioTransmitterInputData(int[] ah, int d)
            {
                _homeLocations = ah;
                _transmitterDistance = d;
            }
        }

        [Test]
        public void HackerRankTest00()
        {
            HackerlandRadioTransmitterInputData data = GetInputData(_sTestDataRootDir + "hackerrank00_input.txt");
            HackerlandRadioTransmitters.NumHouses = data._homeLocations.Length;
            HackerlandRadioTransmitters.TowerRadius = data._transmitterDistance;
            HackerlandRadioTransmitters.HomeLocations = data._homeLocations;

            int result = HackerlandRadioTransmitters.hackerlandRadioTransmitters();
            int expected = 2;

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void HackerRankTest2()
        {
            HackerlandRadioTransmitterInputData data = GetInputData(_sTestDataRootDir + "hackerrank2_input.txt");
            HackerlandRadioTransmitters.NumHouses = data._homeLocations.Length;
            HackerlandRadioTransmitters.TowerRadius = data._transmitterDistance;
            HackerlandRadioTransmitters.HomeLocations = data._homeLocations;

            int result = HackerlandRadioTransmitters.hackerlandRadioTransmitters();
            int expected = 4;

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void HackerRankTest3()
        {
            HackerlandRadioTransmitterInputData data = GetInputData(_sTestDataRootDir + "hackerrank3_input.txt");
            HackerlandRadioTransmitters.NumHouses = data._homeLocations.Length;
            HackerlandRadioTransmitters.TowerRadius = data._transmitterDistance;
            HackerlandRadioTransmitters.HomeLocations = data._homeLocations;

            int result = HackerlandRadioTransmitters.hackerlandRadioTransmitters();
            int expected = 1;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void HackerRankTest6()
        {
            HackerlandRadioTransmitterInputData data = GetInputData(_sTestDataRootDir + "hackerrank6_input.txt");
            HackerlandRadioTransmitters.NumHouses = data._homeLocations.Length;
            HackerlandRadioTransmitters.TowerRadius = data._transmitterDistance;
            HackerlandRadioTransmitters.HomeLocations = data._homeLocations;

            int result = HackerlandRadioTransmitters.hackerlandRadioTransmitters();
            int expected = 620;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void HackerRankTest7()
        {
            HackerlandRadioTransmitterInputData data = GetInputData(_sTestDataRootDir + "hackerrank7_input.txt");
            HackerlandRadioTransmitters.NumHouses = data._homeLocations.Length;
            HackerlandRadioTransmitters.TowerRadius = data._transmitterDistance;
            HackerlandRadioTransmitters.HomeLocations = data._homeLocations;

            int result = HackerlandRadioTransmitters.hackerlandRadioTransmitters();
            int expected = 972;
            Assert.AreEqual(result, expected);
        }

        private HackerlandRadioTransmitterInputData GetInputData(string inFile)
        {
            int[] homelocations;
            int k;
            using (StreamReader file = new StreamReader(inFile))
            {
                int[] nk = new int[2];
                nk = Array.ConvertAll(file.ReadLine().Split(' '), i => Convert.ToInt32(i));
                int n = nk[0];
                k = nk[1];
                homelocations = new int[n];
                homelocations = Array.ConvertAll(file.ReadLine().Split(' '), i => Convert.ToInt32(i));
            }
            return new HackerlandRadioTransmitterInputData(homelocations, k);
        }
    }
}
