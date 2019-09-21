using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions
{
    public class JesseAndCookies
    {
        #region solution
        private static SortedList<int, int> lCookies = new SortedList<int, int>();

        private static void AddNewCookie(int iMixedCookieSweetness)
        {
            if (lCookies.ContainsKey(iMixedCookieSweetness))
            {
                lCookies[iMixedCookieSweetness]++;
            }
            else
            {
                lCookies.Add(iMixedCookieSweetness, 1);
            }
        }

        private static void SmartRemoveElementAt(int location)
        {
            if (location >= lCookies.Count || location < 0) return;
            var kvCookie = lCookies.ElementAt(location);
            if (kvCookie.Value == 1)
            {
                lCookies.RemoveAt(location);
            }
            else
            {
                lCookies[kvCookie.Key]--;
            }
        }

        private static void LoadCookieData(int[] aCookieSweetnessVals)
        {
            // we need to handle duplicate entries in the cookie sweetness list
            foreach (int v in aCookieSweetnessVals)
            {
                if (lCookies.ContainsKey(v))
                {
                    lCookies[v]++;
                }
                else
                {
                    lCookies.Add(v, 1);
                }
            }
        }
        private static int MixCookies()
        {
            // get the first two cookies in the list
            int iMixedCookieSweetness = lCookies.ElementAt(0).Key;
            SmartRemoveElementAt(0);
            iMixedCookieSweetness += 2 * lCookies.ElementAt(0).Key;
            SmartRemoveElementAt(0);
            return iMixedCookieSweetness;
        }

        public static int cookies(int k, int[] A)
        {
            lCookies.Clear();
            LoadCookieData(A);
            int iNumCookieMixesCount = 0;
            while (lCookies.Any(v => v.Key < k) && lCookies.Sum(s => s.Value) >= 2)
            {
                int iNewSweetnessLevel = MixCookies();
                AddNewCookie(iNewSweetnessLevel);
                iNumCookieMixesCount++;
            }
            return (lCookies.Count == 1 && lCookies.ElementAt(0).Key < k) ? -1 : iNumCookieMixesCount;
        }
        #endregion
    }
}
