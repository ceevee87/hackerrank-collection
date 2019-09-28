using DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions
{
    public class JesseAndCookies
    {
        #region solution
        private static IHeap _heap;

        private static void AddNewCookie(int iMixedCookieSweetness)
        {
            _heap.Push(iMixedCookieSweetness);
        }

        private static void LoadCookieData(int[] aCookieSweetnessVals)
        {
            foreach (int v in aCookieSweetnessVals)
            {
                _heap.Push(v);
            }
        }
        private static int MixCookies()
        {
            // get the first two cookies in the list
            int iMixedCookieSweetness = _heap.Pop();
            iMixedCookieSweetness += 2 * _heap.Pop();
            return iMixedCookieSweetness;
        }

        public static int cookies(int k, int[] A)
        {
            _heap = new MinHeap(A.Length);

            LoadCookieData(A);
            //_heap.print();

            int iNumCookieMixesCount = 0;

            while (_heap.Peek < k && _heap.Size > 1)
            {
                int iNewSweetnessLevel = MixCookies();
                AddNewCookie(iNewSweetnessLevel);
                iNumCookieMixesCount++;
            }
            return (_heap.Size == 1 && _heap.Peek < k) ? -1 : iNumCookieMixesCount;
        }
        #endregion
    }
}
