using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class QHeap1Tests
    {
        [TestMethod]
        public void Test1()
        {
            string[] queries = new string[] { "1 4", "1 9", "3", "2 4", "3" };
            int[] result = QHeap1.ProcessQueries(queries);
            int[] expected = new int[] { 4, 9 };
            CollectionAssert.AreEqual(expected, result);
        }

    }
}
