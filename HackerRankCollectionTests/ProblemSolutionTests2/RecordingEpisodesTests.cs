using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollectionTests.ProblemSolutionTests2
{
    [TestFixture]
    public class RecordingEpisodesTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
                    , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
                    , @"TestData\NoPrefixSet");

        public void InitialTest()
        {
            Assert.IsTrue(true);
        }


        private List<int[][]> GetInputData(string inFile)
        {
            List<int[][]> res = new List<int[][]>();

            using (StreamReader fsr = new StreamReader(inFile))
            {
                int q = Convert.ToInt32(fsr.ReadLine());

                for (int qItr = 0; qItr < q; qItr++)
                {
                    int n = Convert.ToInt32(fsr.ReadLine());

                    int[][] episodes = new int[n][];

                    for (int episodesRowItr = 0; episodesRowItr < n; episodesRowItr++)
                    {
                        episodes[episodesRowItr] = Array.ConvertAll(fsr.ReadLine().Split(' '), t => Convert.ToInt32(t));
                    }
                    res.Add(episodes);
                }
            }
            return res;
        }

        private List<int[]> GetAnswerData(string ansFile, int lineCnt)
        {
            List<int[]> res = new List<int[]>();

            using (StreamReader fsr = new StreamReader(ansFile))
            {
                for (int qItr = 0; qItr < lineCnt; lineCnt++)
                {
                    int[] periods = Array.ConvertAll(fsr.ReadLine().Split(' '), t => Convert.ToInt32(t));
                    res.Add(periods);
                }
            }
            return res;
        }
    }
}