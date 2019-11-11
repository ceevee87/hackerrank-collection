using System;
using System.Collections.Generic;

namespace HackerRankCollection.ProblemSolutions2
{
    public static class SaveHumanity
    {
        private static long _bigPrime = 536870923; //7379219697821987;
        private static long[] _powers;
        private static long _exponentBase = 26;
        private static long _maxHashDistance;
        public static uint _toleranceCheckCounter;
        public static uint _equalityCheckCounter;

        public static long BigPrime
        {
            set { _bigPrime = value; }
            get { return _bigPrime; }
        }

        public static long ExponentBase
        {
            set { _exponentBase = value; }
            get { return _exponentBase; }
        }


        public static uint EqualityCheckCounter
        {
            set { _equalityCheckCounter = value; }
            get { return _equalityCheckCounter; }
        }

        public static uint ToleranceCheckCounter
        {
            set { _toleranceCheckCounter = value; }
            get { return _toleranceCheckCounter; }
        }


        public static long CalculateNewRollingHash(long rollingHash, char newc, char oldc, int loc)
        {
            long res = (rollingHash + _bigPrime - (char)(oldc) * _powers[loc] % _bigPrime) % _bigPrime;
            res = (res + (char)(newc) * _powers[loc] % _bigPrime) % _bigPrime;
            return res;
        }

        private static void InitMaxHashDistance(string v)
        {
            long baseHash = CalculateStringHash(v);

            for (int ii = 0; ii < v.Length; ii++)
            {
                long h1 = CalculateNewRollingHash(baseHash, 'a', v[ii], ii);
                long h2 = CalculateNewRollingHash(baseHash, 'z', v[ii], ii);

                _maxHashDistance = Math.Max(Math.Max(h1, h2), _maxHashDistance);
            }
        }

        public static void InitPowers(int n)
        {
            // this going to calculate the exponent component of the
            // Rabin-Karp rolling hash. the module with a prime is already 
            // included in these values. 
            _powers = new long[n];

            _powers[n-1] = 1;

            for (int ii = n - 2; ii >= 0; ii--)
            {
                _powers[ii] = (_powers[ii + 1] * _exponentBase) % _bigPrime;
            }
        }

        public static long CalculateStringHash(string v)
        {
            long res = 0;

            // all kinds of error checking is not present
            // is v[ii] - 97 > 0?
            // is 0 <= ii < 26 ?
            // is v null?

            for (int ii = 0; ii < v.Length; ii++)
            {
                res += ((char)(v[ii]) * _powers[ii]);
            }

            res %= _bigPrime;

            return res;
        }

        public static long CalculateNewRollingHash(long rollingHash, string sub)
        {
            long res = (rollingHash + _bigPrime - (char)(sub[0]) * _powers[0] % _bigPrime) % _bigPrime;
            res = (res * _exponentBase + (char)(sub[sub.Length - 1])) % _bigPrime;
            return res;
        }

        private static bool WithinTolerance(string sub, string v, long rollinghash, long virushash)
        {
            if (Math.Abs(rollinghash - virushash) > _maxHashDistance) return false;

            _toleranceCheckCounter++;

            sbyte count = 1;
            for (int ii = 0; ii < v.Length; ii++)
            {
                if (count < 0) return false;
                if (sub[ii] != v[ii])
                {
                    count--;
                }
            }
            return (count >= 0);
        }

        public static int[] GetVirusIndices(string p, string v)
        {
            List<int> lResult = new List<int>();

            InitPowers(v.Length);
            InitMaxHashDistance(v);

            long virusHash = CalculateStringHash(v);
            long rollingHash = CalculateStringHash(p.Substring(0, v.Length));

            for (int ii = 0; ii <= p.Length - v.Length; ii++)
            {
                string sub = p.Substring(ii, v.Length);
                if (virusHash == rollingHash)
                {
                    _equalityCheckCounter++;
                    if (sub.Equals(v))
                    {
                        lResult.Add(ii);
                    }
                }
                else if (WithinTolerance(sub, v, rollingHash, virusHash))
                {
                    lResult.Add(ii);
                }

                // calculate the hash
                if (ii < p.Length - v.Length)
                {
                    rollingHash = CalculateNewRollingHash(rollingHash, p.Substring(ii, v.Length + 1));
                }
            }

            if (lResult.Count == 0)
            {
                lResult.Add(-1);
            }
            return lResult.ToArray();
        }

        public static void virusIndices(string p, string v)
        {
            /*
             * Print the answer for this test case in a single line
             */
            int[] res = GetVirusIndices(p, v);
            if (res[0] == -1)
            {
                Console.WriteLine("No Match!");
            }
            else
            {
                Console.WriteLine(string.Join(" ", res));
            }
        }
    }
}
