using HackerRankCollection.ProblemSolutions;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class EqualStacksTests
    {

        [Test]
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
