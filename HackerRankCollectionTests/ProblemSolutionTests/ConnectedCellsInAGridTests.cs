using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class ConnectedCellsInAGridTests
    {
        private string _sTestDataRootDir = @"..\..\TestData\ConnectedCellsInAGrid\";

        [TestMethod]
        public void PrintNeighborPointCoordsTest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "sample1_input.txt");
            ConnectedCellsInAGrid.InitMatrix(m);

            var refpoint = ConnectedCellsInAGrid.GetPointAt(0, 0);
            ConnectedCellsInAGrid.PrintNeighborCoords(refpoint);
            Debug.WriteLine("");
            refpoint = ConnectedCellsInAGrid.GetPointAt(0, 2);
            ConnectedCellsInAGrid.PrintNeighborCoords(refpoint);
            Debug.WriteLine("");
            refpoint = ConnectedCellsInAGrid.GetPointAt(2, 0);
            ConnectedCellsInAGrid.PrintNeighborCoords(refpoint);
            Debug.WriteLine("");
            refpoint = ConnectedCellsInAGrid.GetPointAt(3, 3);
            ConnectedCellsInAGrid.PrintNeighborCoords(refpoint);
            Debug.WriteLine("");
            refpoint = ConnectedCellsInAGrid.GetPointAt(2, 3);
            ConnectedCellsInAGrid.PrintNeighborCoords(refpoint);
            Debug.WriteLine("");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void HackerRankSampleATest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "sample1_input.txt");
            int expectedResult = 5;
            int result = ConnectedCellsInAGrid.connectedCell(m);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void HackerRankSampleBTest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "sample2_input.txt");
            int expectedResult = 5;
            int result = ConnectedCellsInAGrid.connectedCell(m);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Circle1Test()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "circle1_input.txt");
            //ConnectedCellsInAGrid.InitMatrix(m);
            //ConnectedCellsInAGrid.ColorMatrixRegions();
            //ConnectedCellsInAGrid.PrintMatrix();
            //int result = ConnectedCellsInAGrid.GetMaxColoredRegionSize();

            int result = ConnectedCellsInAGrid.connectedCell(m);
            int expectedResult = 10;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Rectangle1MultipleRegionsTest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "rectangle_size1_input.txt");
            //ConnectedCellsInAGrid.InitMatrix(m);
            //ConnectedCellsInAGrid.ColorMatrixRegions();
            //ConnectedCellsInAGrid.PrintMatrix();
            //int result = ConnectedCellsInAGrid.GetMaxColoredRegionSize();

            int result = ConnectedCellsInAGrid.connectedCell(m);
            int expectedResult = 5;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Rectangle2MultipleRegionsTest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "rectangle_size2_input.txt");
            //ConnectedCellsInAGrid.InitMatrix(m);
            //ConnectedCellsInAGrid.ColorMatrixRegions();
            //ConnectedCellsInAGrid.PrintMatrix();
            //int result = ConnectedCellsInAGrid.GetMaxColoredRegionSize();

            int result = ConnectedCellsInAGrid.connectedCell(m);
            int expectedResult = 6;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Rectangle3MultipleRegionsTest()
        {
            int[][] m = GetInputMatrixFromFile(_sTestDataRootDir + "rectangle_size3_input.txt");
            //ConnectedCellsInAGrid.InitMatrix(m);
            //ConnectedCellsInAGrid.ColorMatrixRegions();
            //ConnectedCellsInAGrid.PrintMatrix();
            //int result = ConnectedCellsInAGrid.GetMaxColoredRegionSize();

            int result = ConnectedCellsInAGrid.connectedCell(m);

            int expectedResult = 16;
            Assert.AreEqual(result, expectedResult);
        }

        private int[][] GetInputMatrixFromFile(string inFile)
        {
            // zero error catching here ... make sure your input is legit

            int[][] rows;
            using (StreamReader file = new StreamReader(inFile))
            {
                int iNumRows = Convert.ToInt32(file.ReadLine());
                int iNumCols = Convert.ToInt32(file.ReadLine());
                rows = new int[iNumRows][];

                for (int ii = 0; ii < iNumRows; ii++)
                {
                    string[] arr = file.ReadLine().Split(' ');
                    rows[ii] = Array.ConvertAll(arr, s => int.Parse(s));
                }
            }
            return rows;
        }

    }

}
