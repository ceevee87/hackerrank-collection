using System;
using System.Collections.Generic;

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
        private static HashSet<string> _prefixes = new HashSet<string>();
        private static HashSet<string> _words = new HashSet<string>();

        private static void InitPrefixAndWordCollections()
        {
            if (_prefixes == null)
            {
                _prefixes = new HashSet<string>();
            }
            _prefixes.Clear();

            if (_words == null)
            {
                _words = new HashSet<string>();
            }
            _words.Clear();
        }

        private static bool RecordWordAndPrefixes(string word)
        {
            if (_words.Contains(word)) return false;
            if (_prefixes.Contains(word)) return false;

            _words.Add(word);

            for (int ii = 1; ii < word.Length; ii++)
            {
                string prefix = word.Substring(0, ii);
                if (_words.Contains(prefix)) return false;
                if (!_prefixes.Contains(prefix))
                {
                    _prefixes.Add(prefix);
                }
            }
            return true;
        }

        public static PrefixCheckResult DoBadPrefixCheck(string[] words)
        {
            InitPrefixAndWordCollections();
            foreach (string w in words)
            {
                // check if word exists in the prefix dictionary as a "prefix" type
                if (!RecordWordAndPrefixes(w)) return new PrefixCheckResult(false, w);
            }
            return new PrefixCheckResult(true, string.Empty);
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

        public static void ProcessNoPrefixSet(string[] args)
        {
            InitPrefixAndWordCollections();
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
