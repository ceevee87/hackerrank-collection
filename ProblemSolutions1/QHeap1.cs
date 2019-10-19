using DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    public static class QHeap1
    {
        public static int[] ProcessQueries(string[] queries)
        {
            List<int> result = new List<int>();
            IQHeap h = new QMinHeap(queries.Length);
            for (int ii = 0; ii< queries.Length; ii++)
            {
                string[] ops = queries[ii].Split(' ');
                if (ops[0].Equals("1"))
                {
                    h.Push(Convert.ToInt32(ops[1]));
                }
                else if (ops[0].Equals("2"))
                {
                    int k = h.Find(Convert.ToInt32(ops[1]));
                    if (k > 0) h.RemoveAt(k);

                }
                else if (ops[0].Equals("3"))
                {
                    result.Add(h.Peek);
                }
            }

            return (result == null) ? null : result.ToArray();
        }

        private static string[] GetInputData()
        {
            int k = Convert.ToInt32(Console.ReadLine());
            string[] result = new string[k];
            for (int ii =0;ii<k;ii++)
            {
                result[ii] = Console.ReadLine();
            }
            return result;
        }
        private static void MainStub(String[] args)
        {
            string[] queries = GetInputData();
            int[] QueryResults = ProcessQueries(queries);

            foreach (int v in QueryResults)
            {
                Console.WriteLine(v.ToString());
            }
        }

    }
}
