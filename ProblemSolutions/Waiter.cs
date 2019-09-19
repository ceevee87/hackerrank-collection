using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class Waiter
    {
        public static List<List<int>> allResultStacks = new List<List<int>>();
        public static List<int> aStack = new List<int>();
        public static List<int> bStack = new List<int>();
        public static List<int> qStack = new List<int>();
        public static int[] aPrimes = GetPrimesUpToLimit(9739);

        public static int[] GetPrimesUpToLimit(int iLastPossiblePrime)
        {
            bool[] aScoreboard = new bool[iLastPossiblePrime + 1];

            /* Set all but 0 and 1 to prime status */
            for (int ii = 0; ii < aScoreboard.Length; ii++) aScoreboard[ii] = true;
            aScoreboard[0] = aScoreboard[1] = false;

            /* Mark all the non-primes */
            int iFactor = 2;

            while (iFactor * iFactor <= iLastPossiblePrime)
            {
                /* Mark the multiples of this factor */
                int mark = iFactor + iFactor;
                while (mark <= iLastPossiblePrime)
                {
                    aScoreboard[mark] = false;
                    mark += iFactor;
                }

                /* Set thisfactor to next prime */
                iFactor++;
                while (!aScoreboard[iFactor]) { iFactor++; }

            }
            /* prepare result */

            List<int> result = new List<int>();
            for (int ii = 2; ii <= iLastPossiblePrime; ii++)
            {
                if (aScoreboard[ii]) result.Add(ii);
            }
            return result.ToArray();
        }

        public static int[] waiter(int[] number, int q)
        {
            aStack.Clear();
            bStack.Clear();
            qStack.Clear();
            allResultStacks.Clear();

            // load up the A stack from number[]
            foreach (int v in number) aStack.Insert(0, v);

            for (int iIteration = 1; iIteration <= q; iIteration++)
            {
                qStack.Clear();
                foreach (int iTopPlateValue in aStack)
                {
                    int iPrimeNumberCheck = aPrimes[iIteration - 1];
                    if ((iTopPlateValue % iPrimeNumberCheck) == 0)
                    {
                        // put the value in the B stack
                        bStack.Insert(0, iTopPlateValue);
                    }
                    else
                    {
                        qStack.Insert(0, iTopPlateValue);
                    }
                }
                aStack.Clear();
                if (qStack.Count > 0) aStack.AddRange(qStack);
                if (bStack.Count > 0) allResultStacks.Add(new List<int>(bStack));
                bStack.Clear();
            }
            if (qStack.Count > 0) allResultStacks.Add(new List<int>(qStack));

            List<int> lResult = new List<int>();
            foreach (var lStack in allResultStacks)
            {
                foreach (var val in lStack)
                {
                    lResult.Add(val);
                }
            }
            return lResult.ToArray();
        }
    }
}

