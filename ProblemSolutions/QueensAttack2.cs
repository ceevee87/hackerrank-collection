using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions
{
    public class QueensAttack2
    {
        private class BoardLoc
        {
            int _row;
            int _col;

            public BoardLoc(int r, int c)
            {
                _row = r;
                _col = c;
            }
        }

        private static int _numRows = 1;
        private static int _numCols = 1;

        private static Dictionary<int, List<int>> bps = new Dictionary<int, List<int>>();
        public static void InitMatrix(int iBoardSize, int iQueenRowLocation, int iQueenColLocation, int[][] aObstacles)
        {
            _numRows = iBoardSize;
            _numCols = iBoardSize;

            bps.Clear();

            for (int ii = 0; ii < aObstacles.Length; ii++)
            {
                int row = aObstacles[ii][0] - 1;
                int col = aObstacles[ii][1] - 1;

                if (bps.ContainsKey(row))
                {
                    bps[row].Add(col);
                }
                else
                {
                    List<int> rowlist = new List<int>();
                    rowlist.Add(col);
                    bps.Add(row, rowlist);
                }
            }
        }

        public static void PrintObstaclesDict()
        {
            List<int> lKeys = bps.Keys.ToList();

            lKeys.Sort();
            foreach (var k in lKeys)
            {
                Debug.Write(string.Format("{0} :",k));
                foreach (var v in bps[k])
                {
                    Debug.Write(string.Format("{0} ", v));
                }
                Debug.WriteLine("");
            }
        }

        private static bool isLocationOnBoard(int row, int col)
        {
            if (row < 0 || row >= _numRows) return false;
            if (col < 0 || col >= _numCols) return false;
            return true;
        }

        private static bool isLocationBlocked(int row, int col)
        {
            if (!bps.ContainsKey(row)) return false;

            foreach (var v in bps[row])
            {
                if (v == col) return true;
            }
            return false;
        }

        private static int GetTotalCountAllLocationsAccessibleFromBoardLocation(int row, int col)
        {
            int iTotalAccessibleLocationCount = 0;
            // go up
            int ii = row + 1;
            int jj = col;
            while (ii < _numRows)
            {
                if (!isLocationOnBoard(ii, col)) break;
                if (isLocationBlocked(ii, col)) break;
                iTotalAccessibleLocationCount++;
                ii++;
            }

            // go diagonal, up and right
            ii = row + 1;
            jj = col + 1;
            while (ii < _numRows && jj < _numCols)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                iTotalAccessibleLocationCount++;
                ii++;
                jj++;
            }

            // go right
            ii = row;
            jj = col + 1;
            while (jj < _numRows)
            {
                if (!isLocationOnBoard(row, jj)) break;
                if (isLocationBlocked(row, jj)) break;
                iTotalAccessibleLocationCount++;
                jj++;
            }

            // go diagonal, down and right
            ii = row - 1;
            jj = col + 1;
            while (ii >= 0 && jj < _numCols)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                iTotalAccessibleLocationCount++;
                ii--;
                jj++;
            }

            // go down
            ii = row - 1;
            jj = col;
            while (ii >= 0)
            {
                if (!isLocationOnBoard(ii, col)) break;
                if (isLocationBlocked(ii, col)) break;
                iTotalAccessibleLocationCount++;
                ii--;
            }

            // go diagonal, down and left
            ii = row - 1;
            jj = col - 1;
            while (ii >= 0 && jj >= 0)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                iTotalAccessibleLocationCount++;
                ii--;
                jj--;
            }

            // go left
            ii = row;
            jj = col - 1;
            while (jj >= 0)
            {
                if (!isLocationOnBoard(row, jj)) break;
                if (isLocationBlocked(row, jj)) break;
                iTotalAccessibleLocationCount++;
                jj--;
            }

            // go diagonal, up and left
            ii = row + 1;
            jj = col - 1;
            while (ii < _numRows && jj >= 0)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                iTotalAccessibleLocationCount++;
                ii++;
                jj--;
            }

            return iTotalAccessibleLocationCount;
        }

        public static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            InitMatrix(n, r_q - 1, c_q - 1, obstacles);
            return GetTotalCountAllLocationsAccessibleFromBoardLocation(r_q - 1, c_q - 1);

        }

        //private static IEnumerable<BoardPoint> GetAllLocationsAccessibleFromBoardLocation(int row, int col)
        //{
        //    List<BoardPoint> result = new List<BoardPoint>();

        //    // go up
        //    int ii = row + 1;
        //    int jj = col;
        //    while (ii < _numRows)
        //    {
        //        if (!isLocationOnBoard(ii, col)) break;
        //        if (isLocationBlocked(ii, col)) break;
        //        result.Add(_matrix[ii][col]);
        //        ii++;
        //    }

        //    // go diagonal, up and right
        //    ii = row + 1;
        //    jj = col + 1;
        //    while (ii < _numRows && jj < _numCols)
        //    {
        //        if (!isLocationOnBoard(ii, jj)) break;
        //        if (isLocationBlocked(ii, jj)) break;
        //        result.Add(_matrix[ii][jj]);
        //        ii++;
        //        jj++;
        //    }

        //    // go right
        //    ii = row;
        //    jj = col + 1;
        //    while (jj < _numRows)
        //    {
        //        if (!isLocationOnBoard(row, jj)) break;
        //        if (isLocationBlocked(row, jj)) break;
        //        _matrix[row][jj].isAccessible = true;
        //        result.Add(_matrix[row][jj]);
        //        jj++;
        //    }

        //    // go diagonal, down and right
        //    ii = row - 1;
        //    jj = col + 1;
        //    while (ii >= 0 && jj < _numCols)
        //    {
        //        if (!isLocationOnBoard(ii, jj)) break;
        //        if (isLocationBlocked(ii, jj)) break;
        //        _matrix[ii][jj].isAccessible = true;
        //        result.Add(_matrix[ii][jj]);
        //        ii--;
        //        jj++;
        //    }

        //    // go down
        //    ii = row - 1;
        //    jj = col;
        //    while (ii >= 0)
        //    {
        //        if (!isLocationOnBoard(ii, col)) break;
        //        if (isLocationBlocked(ii, col)) break;
        //        result.Add(_matrix[ii][col]);
        //        ii--;
        //    }

        //    // go diagonal, down and left
        //    ii = row - 1;
        //    jj = col - 1;
        //    while (ii >= 0 && jj >= 0)
        //    {
        //        if (!isLocationOnBoard(ii, jj)) break;
        //        if (isLocationBlocked(ii, jj)) break;
        //        result.Add(_matrix[ii][jj]);
        //        ii--;
        //        jj--;
        //    }

        //    // go left
        //    ii = row;
        //    jj = col - 1;
        //    while (jj >= 0)
        //    {
        //        if (!isLocationOnBoard(row, jj)) break;
        //        if (isLocationBlocked(row, jj)) break;
        //        result.Add(_matrix[row][jj]);
        //        jj--;
        //    }

        //    // go diagonal, up and left
        //    ii = row + 1;
        //    jj = col - 1;
        //    while (ii < _numRows && jj >= 0)
        //    {
        //        if (!isLocationOnBoard(ii, jj)) break;
        //        if (isLocationBlocked(ii, jj)) break;
        //        result.Add(_matrix[ii][jj]);
        //        ii++;
        //        jj--;
        //    }

        //    return result;
        //}

    }
}
