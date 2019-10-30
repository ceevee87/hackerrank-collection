using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions2
{
    public class PrefixCheckResult
    {
        public bool _result;
        public string _word;

        public PrefixCheckResult(bool r, string w)
        {
            _result = r;
            _word = w;
        }
    }

    public static class NoPrefixSet
    {
        private static Dictionary<string, byte> _prefixDict = new Dictionary<string, byte>();

        private static bool IsWordSafeToAddToPrefixHash(string word)
        {
            if (_prefixDict.ContainsKey(word)) return false;

            // check if any prefixes of the current word are in the 
            // dictionary stored as an entire word.
            for (int ii = 1; ii < word.Length; ii++)
            {
                string prefix = word.Substring(0, ii);
                if (_prefixDict.ContainsKey(prefix) && _prefixDict[prefix] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static void UpdatePreFixHash(string word)
        {
            if (!_prefixDict.ContainsKey(word))
            {
                _prefixDict.Add(word, 1);
            }
            for (int ii = 1; ii < word.Length; ii++)
            {
                string prefix = word.Substring(0, ii);
                if (!_prefixDict.ContainsKey(prefix))
                {
                    _prefixDict.Add(prefix, 0);
                }
            }
        }

        private static string[] GetInputData()
        {
            int k = Convert.ToInt32(Console.ReadLine());
            string[] result = new string[k];
            for (int ii = 0; ii < k; ii++)
            {
                result[ii] = Console.ReadLine();
            }
            return result;
        }

        private static void InitPrefixMap()
        {
            if (_prefixDict == null)
            {
                _prefixDict = new Dictionary<string, byte>();
            }
            _prefixDict.Clear();
        }

        public static PrefixCheckResult DoBadPrefixCheck(string[] words)
        {
            InitPrefixMap();
            foreach (string w in words)
            {
                // check if word exists in the prefix dictionary as a "prefix" type
                if (!IsWordSafeToAddToPrefixHash(w)) return new PrefixCheckResult(false, w);

                // insert all possible prefix combinations of the words into the dictionary
                UpdatePreFixHash(w);
            }
            return new PrefixCheckResult(true, string.Empty);
        }

        public static void ProcessNoPrefixSet(string[] args)
        {
            InitPrefixMap();
            string[] words = GetInputData();
            PrefixCheckResult res = DoBadPrefixCheck(words);
            if (!res._result)
            {
                Console.WriteLine("BAD SET");
                Console.WriteLine(res._word);
            }
            else
            {
                Console.WriteLine("GOOD SET");
            }
        }
    }
}
