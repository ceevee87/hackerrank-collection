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
                if (res.ContainsKey(c))
                {
                    res[c]++;
                }
                else
                {
                    res[c] = 1;
                }
            }
            return res;
        }
        public static string isValid(string s)
        {
            Dictionary<char, int> charHisto = countCharacterOccurences(s);

            if (charHisto == null) return "NO";
            if (charHisto.Count == 1) return "YES";

            bool bStringIsValid = true;
            // if all the occurences equal this occurence count then the
            // string is a valid string

            // we can only deviate once from matching the expected occurence
            // count. also, this deviation can only be by +1

            Dictionary<int, int> countOfCharCounts = new Dictionary<int, int>();
            foreach (char c in charHisto.Keys)
            {
                if (countOfCharCounts.Count > 2)
                {
                    bStringIsValid = false;
                    break;
                }
                if (countOfCharCounts.ContainsKey(charHisto[c])) countOfCharCounts[charHisto[c]]++;
                else countOfCharCounts[charHisto[c]] = 1;
            }
            if (countOfCharCounts.Count > 2) bStringIsValid = false;
            else if (countOfCharCounts.Count == 1) bStringIsValid = true;
            else
            {
                var firstval = countOfCharCounts.First().Value;
                var firstkey = countOfCharCounts.First().Key;
                var lastval = countOfCharCounts.Last().Value;
                var lastkey = countOfCharCounts.Last().Key;

                if (firstval == 1 && firstkey < lastkey) bStringIsValid = false;
                if (lastval == 1 && lastval < firstkey) bStringIsValid = false;
            }
            return (bStringIsValid) ? "YES" : "NO";
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
