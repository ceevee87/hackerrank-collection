using HackerRankCollection.ProblemSolutions2;
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
                    , @"TestData\RecordingEpisodes");


        [TestCase("00")]
        public void HackerrankSampleTests(string testId)
        {
            string inFile = string.Format("{0}sample{1}_input.txt", _sTestDataRootDir, testId);
            string ansFile = string.Format("{0}sample{1}_answer.txt", _sTestDataRootDir, testId);

            List<int[][]> oData = GetInputData(inFile);
            List<int[]> expected = GetAnswerData(ansFile, oData.Count);

            Assert.Multiple(() =>
            {
                for (int ii = 0; ii < oData.Count; ii++)
                {
                    int[] actual = RecordingEpisodes.EpisodeRecording(oData.ElementAt(ii));
                    CollectionAssert.AreEqual(expected.ElementAt(ii), actual);
                }
            });
        }

        [TestCase("1")]
        [TestCase("1A")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("14")]
        public void HackerrankTests(string testId)
        {
            string inFile = string.Format("{0}hackerrank{1}_input.txt", _sTestDataRootDir, testId);
            string ansFile = string.Format("{0}hackerrank{1}_answer.txt", _sTestDataRootDir, testId);

            List<int[][]> oData = GetInputData(inFile);
            List<int[]> expected = GetAnswerData(ansFile, oData.Count);

            Assert.Multiple(() =>
            {
                for (int ii = 0; ii < oData.Count; ii++)
                {
                    int[] actual = RecordingEpisodes.EpisodeRecording(oData.ElementAt(ii));
                    CollectionAssert.AreEqual(expected.ElementAt(ii), actual, string.Format("Test case {0} failed.",ii+1));
                }
            });
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
                for (int ii = 0; ii < lineCnt; ii++)
                {
                    int[] periods = periods = Array.ConvertAll(fsr.ReadLine().Split(' '), t => Convert.ToInt32(t));
                    res.Add(periods);
                }
            }
            return res;
        }
    }
}