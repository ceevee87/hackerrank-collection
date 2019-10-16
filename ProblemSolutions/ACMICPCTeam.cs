using System;
using System.Collections;

namespace HackerRankCollection.ProblemSolutions
{
    public static class ACMICPCTeam
    {
        private static int GetCardinality(BitArray bitArray)
        {
            // straight hacking
            // https://stackoverflow.com/questions/5063178/counting-bits-set-in-a-net-bitarray-class

            int[] ints = new int[(bitArray.Count >> 5) + 1];

            bitArray.CopyTo(ints, 0);

            Int32 count = 0;

            // fix for not truncated bits in last integer that may have been set to true with SetAll()
            ints[ints.Length - 1] &= ~(-1 << (bitArray.Count % 32));

            for (int i = 0; i < ints.Length; i++)
            {
                int c = ints[i];

                // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                unchecked
                {
                    c = c - ((c >> 1) & 0x55555555);
                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                }
                count += c;
            }

            return count;

        }
        private static BitArray StringToBitArray(string s)
        {
            bool[] fool = new bool[s.Length];

            for (int ii = 0; ii < s.Length; ii++)
            {
                fool[ii] = (s[ii].Equals('1')) ? true : false;
            }
            return new BitArray(fool);
        }

        private static BitArray[] ConvertStringArrayToBitArray(string[] topic)
        {
            BitArray[] result = new BitArray[topic.Length];
            for (int ii = 0; ii < topic.Length; ii++)
            {
                result[ii] = StringToBitArray(topic[ii]);
            }
            return result;
        }

        public static int[] GetMaxTeamSkillCombos(BitArray[] teamSkills)
        {
            int teamcount = 0;
            int maxskillcount = 0;
            for (int ii = 0; ii < teamSkills.Length - 1; ii++)
            {
                for (int jj = ii + 1; jj < teamSkills.Length; jj++)
                {
                    BitArray tmp = new BitArray(teamSkills[ii]);
                    tmp.Or(teamSkills[jj]);
                    int skillcount = GetCardinality(tmp);
                    if (skillcount > maxskillcount)
                    {
                        teamcount = 1;
                        maxskillcount = skillcount;
                    }
                    else if (skillcount == maxskillcount)
                    {
                        teamcount++;
                    }
                }
            }

            return new int[2] { maxskillcount, teamcount };
        }

        public static int[] acmTeam(string[] topic)
        {
            BitArray[] teamSkills = ConvertStringArrayToBitArray(topic);
            return GetMaxTeamSkillCombos(teamSkills);
        }

        private static void MainXXX(string[] args)
        {
            // I didn't write any tests. I had this code in Solution.Main.
            // all the code above passed on the 1st attempt.
            string[] input = new string[3] { "10101", "11110", "00010" };  // 5 1
            string[] input2 = new string[4] { "10101", "11100", "11010", "00101" }; // 5 2
            string[] input3 = new string[6] { "11101", "10101", "11001", "10111", "10000", "01110" }; // 5 6

            int[] result = acmTeam(input3);
        }
    }
}
