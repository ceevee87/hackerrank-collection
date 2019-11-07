using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static string _debugMsg;

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

        public static long BigPrime
        {
            set { _bigPrime = value; }
            get { return _bigPrime; }
        }

        private static void InitMaxHashDistance(int length)
        {
            _maxHashDistance = (long)('z' - 'a') * _powers[length - 1];
        }

        public static void InitPowers(int n)
        {
            Stopwatch sw = new Stopwatch();
            // this going to calculate the exponent component of the
            // Rabin-Karp rolling hash. the module with a prime is already 
            // included in these values. 
            _powers = new long[n];

            sw.Start();
            for (int ii = 0; ii < _powers.Length; ii++) _powers[ii] = 1;

            for (int ii = 1; ii < _powers.Length; ii++)
            {
                _powers[ii] = (_powers[ii - 1] * _exponentBase) % _bigPrime;
            }
            sw.Stop();
            Debug.WriteLine(string.Format("InitPowers : Time elapsed: {0} seconds", (float)sw.ElapsedMilliseconds / 1000.0));
        }

        private static long getCharValueForHashCalculation(char c)
        {
            // no error checking 
            return (long)c - 96;
        }

        public static long CalculateStringHash(string v)
        {
            long res = 0;

            // all kinds of error checking is not present
            // is v[ii] - 97 > 0?
            // is 0 <= ii < 26 ?
            // is v null?

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            for (int ii = 0; ii < v.Length; ii++)
            {
                res += getCharValueForHashCalculation(v[ii]) * _powers[v.Length - ii - 1];
            }

            //sw.Stop();
            //Debug.WriteLine(string.Format("CalculateStringHash ({0}): Time elapsed: {1} milliseconds", _debugMsg, sw.ElapsedMilliseconds));

            return res;
        }

        public static long CalculateNewRollingHash(long rollingHash, string sub, int n)
        {
            long res;
            res = _exponentBase * (rollingHash - getCharValueForHashCalculation(sub[0]) * _powers[n]) + getCharValueForHashCalculation(sub[sub.Length - 1]);
            return res;
        }

        private static bool WithinTolerance(string sub, string v, long rollinghash, long virushash)
        {
            //if (Math.Abs(rollinghash - virushash) > _maxHashDistance) return false;
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
            InitMaxHashDistance(v.Length);

            _debugMsg = "virus hash";
            long virusHash = CalculateStringHash(v);
            _debugMsg = "initial dna hash";
            long rollingHash = CalculateStringHash(p.Substring(0, v.Length));
            _debugMsg = string.Empty;

            for (int ii = 0; ii <= p.Length - v.Length; ii++)
            {
                string sub = p.Substring(ii, v.Length);
                //if (ii > 0)
                //{
                //    rollingHash = CalculateStringHash(sub);
                //}
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
                    rollingHash = CalculateNewRollingHash(rollingHash, p.Substring(ii, v.Length + 1), v.Length - 1);
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
