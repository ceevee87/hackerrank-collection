using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class Contacts
    {
        private static Dictionary<string, List<string>> prefixHash = new Dictionary<string, List<string>>();

        private static int[] GetContactQueryCounts(string[][] queries)
        {
            int iNumFindRequests = queries.Where(a => a[0].ToLower().Equals("find")).Count();
            int[] result = new int[iNumFindRequests];
            int iFindCounter = 0;

            for (int ii = 0; ii < queries.Length; ii++)
            {
                if (queries[ii][0].ToLower().Equals("add"))
                {
                    UpdatePreFixHash(queries[ii][1]);
                }
                else if (queries[ii][0].ToLower().Equals("find"))
                {
                    var sSearchString = queries[ii][1];
                    if (prefixHash.ContainsKey(sSearchString))
                    {
                        result[iFindCounter] = prefixHash[sSearchString].Count;
                    }
                    else
                    {
                        result[iFindCounter] = 0;
                    }
                    iFindCounter++;
                }
            }
            return result;
        }

        private static void UpdatePreFixHash(string sContactName)
        {
            for (int ii = 1; ii <= sContactName.Length; ii++)
            {
                string prefix = sContactName.Substring(0, ii);
                if (prefixHash.ContainsKey(prefix))
                {
                    prefixHash[prefix].Add(sContactName);
                }
                else
                {
                    prefixHash.Add(prefix, new List<string> { sContactName });
                }
            }
        }
        public static int[] contacts(string[][] queries)
        {
            prefixHash.Clear();
            return GetContactQueryCounts(queries);
        }

    }
}
