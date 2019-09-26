using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class QueensAttack2Tests
    {
        private string _sTestDataRootDir = @"..\..\TestData\QueensAttack2\";

        private class QueensAttackInputData
        {
            public readonly int[][] aObstacleLocations;
            public readonly int iQueenRow;
            public readonly int iQueenCol;
            public readonly int iNumObstacles;
            public readonly int iBoardSize;

            public QueensAttackInputData(int n, int k, int rq, int cq, int[][] obstacles)
            {
                aObstacleLocations = obstacles;
                iQueenCol = cq;
                iQueenRow = rq;
                iNumObstacles = k;
                iBoardSize = n;
            }
        }

        [TestMethod]
        public void HackerRankSampleATest()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "sample1_input.txt");
            
            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void HugeTest1()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "huge1_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 31294);
        }

        [TestMethod]
        public void HugeTest2()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "huge2_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 27475);
        }

        [TestMethod]
        public void HackerRankTestCase19()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "testcase19_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 30544);
        }

        [TestMethod]
        public void HackerRankTestCase13()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "testcase13_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 307303);
        }

        [TestMethod]
        public void HackerRankTestCase5()
        {
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "testcase5_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 21);
        }

        [TestMethod]
        public void HackerRankTestCase6()
        {
            // test case 6 answer is 40 from hackerrank 
            QueensAttackInputData oData = GetInputMatrixFromFile(_sTestDataRootDir + "testcase6dbg_input.txt");

            int result = QueensAttack2.queensAttack(oData.iBoardSize, oData.iNumObstacles, oData.iQueenRow, oData.iQueenCol, oData.aObstacleLocations);
            Assert.AreEqual(result, 40);
        }


        private QueensAttackInputData GetInputMatrixFromFile(string inFile)
        {
            // zero error catching here ... make sure your input is legit

            int[][] obstacles;
            int iBoardSize;
            int iNumObstacles;
            int iQueenRow;
            int iQueenCol;
            using (StreamReader file = new StreamReader(inFile))
            {
                string[] nk = file.ReadLine().Split(' ');
                iBoardSize = Convert.ToInt32(nk[0]);
                iNumObstacles = Convert.ToInt32(nk[1]);

                // queens location
                string[] rc = file.ReadLine().Split(' ');
                iQueenRow = Convert.ToInt32(rc[0]);
                iQueenCol = Convert.ToInt32(rc[1]);

                obstacles = new int[iNumObstacles][];
                for (int ii = 0; ii < iNumObstacles; ii++)
                {
                    obstacles[ii] = new int[2];
                }

                for (int ii = 0; ii < iNumObstacles; ii++)
                {
                    obstacles[ii] = Array.ConvertAll(file.ReadLine().Split(' '), a => Convert.ToInt32(a));
                }
            }
            return new QueensAttackInputData(iBoardSize, iNumObstacles, iQueenRow, iQueenCol, obstacles);
        }
    }
}
