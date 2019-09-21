using System.Collections.Generic;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions
{
    public class QueensAttack2
    {
        private class BoardPoint
        {
            public bool isBlocked;
            public bool isAccessible;
            public bool isQueensLocation;

            public BoardPoint()
            {
                isAccessible = false;
                isBlocked = false;
                isQueensLocation = false;
            }
        }

        private static BoardPoint[][] _matrix;
        private static int _numRows = 1;
        private static int _numCols = 1;

        public static void InitMatrix(int iBoardSize, int iQueenRowLocation, int iQueenColLocation, int[][] aObstacles)
        {
            _numRows = iBoardSize;
            _numCols = iBoardSize;
            _matrix = new BoardPoint[_numRows][];
            for (int ii = 0; ii < _numRows; ii++)
            {
                _matrix[ii] = new BoardPoint[_numCols];
                for (int jj = 0; jj < _numCols; jj++)
                {
                    _matrix[ii][jj] = new BoardPoint();
                }
            }

            _matrix[iQueenRowLocation][iQueenColLocation].isQueensLocation = true;

            for (int ii = 0; ii < aObstacles.Length; ii++)
            {
                int row = aObstacles[ii][0] - 1;
                int col = aObstacles[ii][1] - 1;
                _matrix[row][col].isBlocked = true;
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
            return _matrix[row][col].isBlocked;
        }
        private static IEnumerable<BoardPoint> GetAllLocationsAccessibleFromBoardLocation(int row, int col)
        {
            List<BoardPoint> result = new List<BoardPoint>();

            // go up
            int ii = row + 1;
            int jj = col;
            while (ii < _numRows)
            {
                if (!isLocationOnBoard(ii, col)) break;
                if (isLocationBlocked(ii, col)) break;
                result.Add(_matrix[ii][col]);
                ii++;
            }

            // go diagonal, up and right
            ii = row + 1;
            jj = col + 1;
            while (ii < _numRows && jj < _numCols)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                result.Add(_matrix[ii][jj]);
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
                _matrix[row][jj].isAccessible = true;
                result.Add(_matrix[row][jj]);
                jj++;
            }

            // go diagonal, down and right
            ii = row - 1;
            jj = col + 1;
            while (ii >= 0 && jj < _numCols)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                _matrix[ii][jj].isAccessible = true;
                result.Add(_matrix[ii][jj]);
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
                result.Add(_matrix[ii][col]);
                ii--;
            }

            // go diagonal, down and left
            ii = row - 1;
            jj = col - 1;
            while (ii >= 0 && jj >= 0)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                result.Add(_matrix[ii][jj]);
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
                result.Add(_matrix[row][jj]);
                jj--;
            }

            // go diagonal, up and left
            ii = row + 1;
            jj = col - 1;
            while (ii < _numRows && jj >= 0)
            {
                if (!isLocationOnBoard(ii, jj)) break;
                if (isLocationBlocked(ii, jj)) break;
                result.Add(_matrix[ii][jj]);
                ii++;
                jj--;
            }

            return result;
        }

        public static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            InitMatrix(n, r_q-1, c_q-1, obstacles);
            var foo = GetAllLocationsAccessibleFromBoardLocation(r_q - 1, c_q - 1);
            foreach (BoardPoint p in foo)
            {
                p.isAccessible = true;
            }
            return foo.Count();
        }
    }
}
