using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public class LilysHomework
    {
        public static int lilysHomework(int[] arr)
        {
            int[] arrc = (int []) arr.Clone();

            Array.Sort(arrc);

            int iMismatchCount = 0;
            for (int ii = 0; ii < arr.Length; ii++)
            {
                if (arr[ii] != arrc[ii]) iMismatchCount++;
            }
            return iMismatchCount - 1;
        }
    }
}
