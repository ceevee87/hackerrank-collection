using System;
using System.Numerics;

namespace HackerRankCollection.ProblemSolutions
{
    public class ExtraLongFactorials
    {
        public static void extraLongFactorials(int n)
        {
            Console.WriteLine(CalcExtraLongFactorial(n).ToString());
        }

        public static BigInteger CalcExtraLongFactorial(int n)
        {
            if (n < 2) return 1;

            BigInteger res = 1;
            for (int ii = 2; ii <=n; ii++)
            {
                res *= ii;
            }
            return res;
        }
    }
}
