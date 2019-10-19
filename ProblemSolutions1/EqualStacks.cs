using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class EqualStacks
    {
        private static List<int> createRunningSumList(int[] arr)
        {
            List<int> res = new List<int>();

            if (arr.Length == 0) return null;

            int iRunningSum = 0;
            for (int ii = 0; ii < arr.Length; ii++)
            {
                iRunningSum += arr[ii];
                res.Add(iRunningSum);
            }
            return res;
        }
        public static int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            /*
             * Write your code here.
             */
            List<int> lAllRunningSums;
            List<int> lRunningSums;

            Array.Reverse(h1);
            lAllRunningSums = createRunningSumList(h1);

            Array.Reverse(h2);
            lRunningSums = createRunningSumList(h2);
            lAllRunningSums.AddRange(lRunningSums);

            Array.Reverse(h3);
            lRunningSums = createRunningSumList(h3);
            lAllRunningSums.AddRange(lRunningSums);

            lAllRunningSums.Sort();
            lAllRunningSums.Reverse();

            Dictionary<int, int> sumHisto = new Dictionary<int, int>();
            foreach (int totalStackHeight in lAllRunningSums)
            {
                if (sumHisto.ContainsKey(totalStackHeight)) sumHisto[totalStackHeight]++;
                else sumHisto[totalStackHeight] = 1;

                if (sumHisto[totalStackHeight] == 3) return totalStackHeight;
            }
            return 0;
        }
    }
}
