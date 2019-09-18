using System;
using System.Collections.Generic;
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
            if (charHisto.Count == 1) return "YES";

            List<int> lCharacterCounts = charHisto.Values.ToList();
            lCharacterCounts.Sort();
            lCharacterCounts.Reverse();

            // the list must be at least two long. we already trap above the
            // case where the list count == 1 and return "YES"
            int iHighestCharCount = lCharacterCounts.ElementAt(0);
            for (int ii = 1; ii < lCharacterCounts.Count; ii++)
            {
                if (!lCharacterCounts.ElementAt(ii).Equals(iHighestCharCount - 1)) return "NO";
            }

            return "YES";
        }

        public static void getStringToTestFromConsole()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = isValid(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
