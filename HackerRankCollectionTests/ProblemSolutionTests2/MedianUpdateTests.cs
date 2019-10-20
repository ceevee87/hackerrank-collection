using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankCollection.ProblemSolutions2;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests2
{
    [TestFixture]
    public class MedianUpdateTests
    {
        string _sTestDataRootDir = string.Format(@"{0}\{1}\"
            , Path.GetDirectoryName(Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName)
            , @"TestData\MedianUpdate");

        internal class InputDataMedianUpdate
        {
            public string[] actions;
            public int[] heapArgs;

            public InputDataMedianUpdate(string[] a, int[] vals)
            {
                actions = a;
                heapArgs = vals;
            }
        }

        [Test]
        public void sample1Test()
        {
            InputDataMedianUpdate oData = GetInputData(_sTestDataRootDir + "sample1_input.txt");
            string[] result = MedianUpdates.ProcessHeapCommands(oData.actions, oData.heapArgs);
            string[] expected = GetAnswerData(_sTestDataRootDir + "sample1_answer.txt", oData.actions.Length);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerrankTest1()
        {
            InputDataMedianUpdate oData = GetInputData(_sTestDataRootDir + "hackerrank1_input.txt");
            string[] result = MedianUpdates.ProcessHeapCommands(oData.actions, oData.heapArgs);
            string[] expected = GetAnswerData(_sTestDataRootDir + "hackerrank1_answer.txt", oData.actions.Length);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerrankTest4()
        {
            InputDataMedianUpdate oData = GetInputData(_sTestDataRootDir + "hackerrank4_input.txt");
            string[] result = MedianUpdates.ProcessHeapCommands(oData.actions, oData.heapArgs);
            string[] expected = GetAnswerData(_sTestDataRootDir + "hackerrank4_answer.txt", oData.actions.Length);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerrankTest8()
        {
            InputDataMedianUpdate oData = GetInputData(_sTestDataRootDir + "hackerrank8_input.txt");
            string[] result = MedianUpdates.ProcessHeapCommands(oData.actions, oData.heapArgs);
            string[] expected = GetAnswerData(_sTestDataRootDir + "hackerrank8_answer.txt", oData.actions.Length);
            CollectionAssert.AreEqual(expected, result);
        }

        private InputDataMedianUpdate GetInputData(string inputFile)
        {
            int N;
            int[] x;
            string[] s;
            using (StreamReader fsr = new StreamReader(inputFile))
            {
                N = Convert.ToInt32(fsr.ReadLine());
                x = new int[N];
                s = new string[N];

                for (int i = 0; i < N; i++)
                {

                    string tmp = fsr.ReadLine();
                    string[] split = tmp.Split(new Char[] { ' ', '\t', '\n' });

                    s[i] = split[0].Trim();
                    x[i] = Convert.ToInt32(split[1].Trim());
                }
            }
            return new InputDataMedianUpdate(s, x);
        }

        private string[] GetAnswerData(string sFileName, int numLineToRead)
        {
            string[] result = new string[numLineToRead];
            using (StreamReader fsr = new StreamReader(sFileName))
            {
                for (int ii = 0; ii < numLineToRead; ii++)
                {
                    result[ii] = fsr.ReadLine().Trim();
                }
            }
            return result;
        }
    }
}
