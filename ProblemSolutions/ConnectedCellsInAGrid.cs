using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRankCollection.ProblemSolutions
{
    public class MatrixPoint
    {
        private readonly int _col;
        private readonly int _row;
        private int _color;
        private bool _fill;

        public int Col => _col;
        public int Row => _row;
        public int Color { get => _color; set => _color = value; }
        public bool Fill { get => _fill; set => _fill = value; }
        public bool IsVisited => (_color > 0);


        public MatrixPoint(int rownum, int colnum, bool isFilled)
        {
            _row = rownum;
            _col = colnum;
            _fill = isFilled;
            _color = 0;  // has not been visited yet
        }
    }

    public static class ConnectedCellsInAGrid
    {
        private static MatrixPoint[][] _matrix;
        private static int _numRows = 1;
        private static int _numCols = 1;

        public static void InitMatrix(int[][] matrix)
        {
            _numRows = matrix.Length;
            _numCols = matrix[0].Length;
            _matrix = new MatrixPoint[_numRows][];
            for (int ii = 0; ii < _numRows; ii++)
            {
                _matrix[ii] = new MatrixPoint[_numCols];
            }

            for (int ii = 0; ii < _numCols; ii++)
            {
                for (int jj = 0; jj < _numRows; jj++)
                {
                    var p = new MatrixPoint(ii, jj, ((matrix[ii][jj] == 1) ? true : false));
                    _matrix[ii][jj] = p;
                }
            }

            PrintMatrix();
        }

        public static void PrintMatrix()
        {
            for (int ii = 0; ii < _numCols; ii++)
            {
                for (int jj = 0; jj < _numRows; jj++)
                {
                    Debug.Write(((_matrix[ii][jj].Fill) ? "1 " : "0 "));
                }
                Debug.WriteLine("");
            }
        }

        public static void InitMatrixSize(int i, int j)
        {
            _numRows = i;
            _numCols = j;
            _matrix = new MatrixPoint[_numRows][];
            for (int ii = 0; ii < _numRows; ii++)
            {
                _matrix[ii] = new MatrixPoint[_numCols];
            }
        }

        public static void InitMatrixRow(MatrixPoint[] aRowData, int row)
        {
            // the size of aRowData needs to be exactly _numCols
            // we'll check for that when code refinement is done

            if (row >= _numRows) return;
            if (!(aRowData.Length == _numCols)) return;
            for (int jj = 0; jj < ((aRowData.Length > _numCols) ? _numCols : aRowData.Length); jj++)
            {
                _matrix[row][jj] = aRowData[jj];
            }
        }

        public static void resetMatrixVisitedPointsStatus()
        {
            for (int ii = 0; ii < _numCols; ii++)
            {
                for (int jj = 0; jj < _numRows; jj++)
                {
                    _matrix[ii][jj].Color = 0;
                }
            }
        }

        public static MatrixPoint GetPointAt(int row, int col)
        {
            if (row >= _numRows || row < 0) return null;
            if (col >= _numCols || col < 0) return null;
            return _matrix[row][col];
        }

        public static IEnumerable<MatrixPoint> GetNeighborPoints(MatrixPoint p)
        {
            // iteration is done from -1,-1 to +1, +1 points from the point p
            // that is, if the point's location is 4,5 then the iteration starts at
            // 3,4 and goes to 5,6.
            List<MatrixPoint> result = new List<MatrixPoint>();
            for (int ii = p.Row - 1; ii <= p.Row + 1; ii++)
            {
                for (int jj = p.Col - 1; jj <= p.Col + 1; jj++)
                {
                    if (jj == p.Col && ii == p.Row) continue;
                    if (jj < 0 || jj >= _numCols) continue;
                    if (ii < 0 || ii >= _numRows) continue;
                    result.Add(_matrix[ii][jj]);
                }
            }
            return result;
        }

        public static void PrintNeighborCoords(MatrixPoint refpoint)
        {
            if (refpoint != null)
            {
                foreach (MatrixPoint p in ConnectedCellsInAGrid.GetNeighborPoints(refpoint))
                {
                    string s = string.Format("({0},{1})", p.Row, p.Col);
                    Debug.WriteLine(s);
                }
            }
        }
    }
}