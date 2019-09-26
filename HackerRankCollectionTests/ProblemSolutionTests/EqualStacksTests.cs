using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class EqualStacksTests
    {

        [TestMethod]
        public void PassTest1()
        {
            int[] stack1 = new int[] { 3, 2, 1, 1, 1 };
            int[] stack2 = new int[] { 4, 3, 2 };
            int[] stack3 = new int[] { 1, 1, 4, 1 };

            int res = EqualStacks.equalStacks(stack1, stack2, stack3);
            Assert.AreEqual(5, res);

        }
    }
}
