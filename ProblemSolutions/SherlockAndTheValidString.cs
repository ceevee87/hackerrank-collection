using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class SherlockAndTheValidString
    {
        private static Dictionary<char, int> countCharacterOccurences(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            var res = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (res.ContainsKey(c)) res[c]++;
                else res[c] = 1;
            }
            return res;
        }

        public static string isValid(string s)
        {
            Dictionary<char, int> charHisto = countCharacterOccurences(s);

            if (charHisto == null) return "NO";

            if (charHisto.Values.Distinct().Count() == 1) return "YES";
            if (charHisto.Values.Distinct().Count() > 2) return "NO";

            List<int> lCharacterCounts = charHisto.Values.ToList();

            int iMaxCountValue = lCharacterCounts.Max();
            int iMinCountValue = lCharacterCounts.Min();

            // do not change the order of the checks below.

            // if the min value only only occurs once we should be good.
            if (charHisto.Where(kv => kv.Value == iMinCountValue).Count() == 1) return "YES";

            if ((iMaxCountValue - iMinCountValue) > 1) return "NO";

            if (charHisto.Where(kv => kv.Value == iMaxCountValue).Count() == 1) return "YES";

            return "NO";
        }

        private static void DebugPrintCharHisto(Dictionary<char, int> d)
        {
            foreach (var kv in d)
            {
                Debug.WriteLine(string.Format("{0}:{1}", kv.Key, kv.Value));
            }
        }
    }
}
