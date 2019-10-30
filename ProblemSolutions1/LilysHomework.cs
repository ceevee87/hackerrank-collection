using System;
using System.Collections.Generic;

namespace HackerRankCollection.ProblemSolutions
{
    public static class LilysHomework
    {
        // index tracker
        // make it fast to lookup a what index a number occupies
        // in the problem input array 
        private static Dictionary<int, int> numbersToIndices;

        private static void MapNumbersToIndices(int[] a)
        {
            if (numbersToIndices == null)
            {
                numbersToIndices = new Dictionary<int, int>();
            }
            numbersToIndices.Clear();

            for (int ii = 0; ii < a.Length; ii++)
            {
                if (numbersToIndices.ContainsKey(a[ii])) continue;
                numbersToIndices.Add(a[ii], ii);
            }
        }

        private static int CalculateNumberOfSwaps(int[] arr, int[] refArray)
        {
            if (arr.Length != refArray.Length) return -1;

            MapNumbersToIndices(arr);

            int numSwaps = 0;
            for (int ii = 0; ii < arr.Length; ii++)
            {
                if (arr[ii] == refArray[ii]) continue;

                // we have a number in 'arr' that is out of place.
                numSwaps++;

                // if we can't find the value of arr[ii] in the dictionary
                // we've got big problems.
                // however, this shouldn't happen because the problem inputs from
                // hackerrank ensure against this. 
                if (!numbersToIndices.ContainsKey(arr[ii])) continue;

                // update the index tracker to account for the swap 
                // we're going to do down below on arr.
                int idx = numbersToIndices[refArray[ii]];
                numbersToIndices[refArray[ii]] = ii;
                numbersToIndices[arr[ii]] = idx;

                // swap arr[ii] with arr[tmp] in current array, arr
                int tmp = arr[ii];
                arr[ii] = arr[idx];
                arr[idx] = tmp;
            }
            return numSwaps;
        }

        public static int lilysHomework(int[] arr)
        {
            int[] numsAsc = new int[arr.Length];
            int[] numsDesc = new int[arr.Length];

            Array.Copy(arr, 0, numsAsc, 0, arr.Length);
            Array.Sort(numsAsc);

            Array.Copy(numsAsc, 0, numsDesc, 0, arr.Length);
            Array.Reverse(numsDesc);

            int x = CalculateNumberOfSwaps((int[])arr.Clone(), numsAsc);
            int y = CalculateNumberOfSwaps((int[])arr.Clone(), numsDesc);

            return Math.Min(x, y);

        }
    }
}
