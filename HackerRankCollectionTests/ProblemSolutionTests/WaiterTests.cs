using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class WaiterTests
    {
        [TestMethod]
        public void SieveOfEratosthenesTest1()
        {
            // 9739 generates 1201 prime numbers
            int[] foo = Waiter.GetPrimesUpToLimit(55);
            foreach (int v in foo)
            {
                Debug.WriteLine(v);
            }
            int[] aExpected = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 };

            //Debug.WriteLine("Number of primes found = " + foo.Length);
            CollectionAssert.AreEqual(foo, aExpected);
        }

        [TestMethod]
        public void WaiterTest1()
        {
            int[] nums = new int[] { 3, 4, 7, 6, 5 };
            int q = 1;

            int[] aExpected = new int[] { 4, 6, 3, 7, 5 };

            CollectionAssert.AreEqual(Waiter.waiter(nums, q), aExpected);
        }

        [TestMethod]
        public void WaiterTest2()
        {
            int[] nums = new int[] { 3, 3, 4, 4, 9 };
            int q = 2;

            int[] aExpected = new int[] { 4, 4, 9, 3, 3 };

            CollectionAssert.AreEqual(Waiter.waiter(nums, q), aExpected);
        }
    }
}
