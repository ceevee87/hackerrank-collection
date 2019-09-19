using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class Contacts
    {
        public static int[] contacts(string[][] queries)
        {
            List<string> lContacts = new List<string>();

            int iNumFindRequests = queries.Where(a => a[0].ToLower().Equals("find")).Count();
            int[] result = new int[iNumFindRequests];
            int iFindCounter = 0;

            for (int ii = 0; ii < queries.Length; ii++)
            {
                if (queries[ii][0].ToLower().Equals("add"))
                {
                    lContacts.Add(queries[ii][1]);
                } else if (queries[ii][0].ToLower().Equals("find"))
                {
                    var sSearchString = queries[ii][1];
                    //var foo = lContacts.Where(c => c.StartsWith(sSearchString));
                    result[iFindCounter++] = lContacts.Where(c => c.StartsWith(sSearchString)).Count();
                }
            }
            return result;
        }
    }
}
