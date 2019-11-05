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
    public class SaveHumanityTests
    {
        readonly string _sTestDataRootDir = string.Format(@"{0}\{1}\"
            , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
            , @"TestData\SaveHumanity");

        [Test]
        public void sampleInput1()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "sampleinput01_input.txt");

            List<string[]> result = new List<string[]>();
            List<string[]> expected = new List<string[]>();

            expected.Add(new string[2] { "1", "2" });
            expected.Add(new string[1] { "No Match!" });
            expected.Add(new string[2] { "0", "2" });

            foreach (string[] arr in oData)
            {
                int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                if (r[0] == -1)
                {
                    result.Add(new string[1] { "No Match!" });
                }
                else
                {
                    result.Add(r.Select(i => i.ToString()).ToArray());
                }
            }
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void sampleInput2()
        {
            List<string[]> oData = GetInputData(_sTestDataRootDir + "sampleinput02_input.txt");

            List<string[]> result = new List<string[]>();
            List<string[]> expected = new List<string[]>();

            expected.Add(new string[2] { "1", "3" });
            expected.Add(new string[2] { "2", "6" });
            expected.Add(new string[3] { "0", "1", "5" });

            foreach (string[] arr in oData)
            {
                int[] r = SaveHumanity.GetVirusIndices(arr[0], arr[1]);
                if (r[0] == -1)
                {
                    result.Add(new string[1] { "No Match!" });
                }
                else
                {
                    result.Add(r.Select(i => i.ToString()).ToArray());
                }
            }
            CollectionAssert.AreEqual(expected, result);
        }

        private List<string[]> GetInputData(string inFile)
        {
            List<string[]> res = new List<string[]>();

            using (StreamReader fsr = new StreamReader(inFile))
            {
                int t = Convert.ToInt32(fsr.ReadLine());

                for (int tItr = 0; tItr < t; tItr++)
                {
                    string[] pv = fsr.ReadLine().Split(' ');
                    res.Add(pv);
                }
            }
            return res;
        }
    }
}
