using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class ExtraLongFactorialTests
    {
        [DataRow(0)]
        [DataRow(1)]
        [DataTestMethod]
        public void BaseCase(int n)
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(n);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void Test50()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(50);
            BigInteger ans = BigInteger.Parse("30414093201713378043612608166064768844377641568960512000000000000");
            Assert.AreEqual(ans, res);
        }

        [TestMethod]
        public void Test25()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(25);
            BigInteger ans = BigInteger.Parse("15511210043330985984000000");
            Assert.AreEqual(ans, res);
        }

        [TestMethod]
        public void Test30()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(30);
            BigInteger ans = BigInteger.Parse("265252859812191058636308480000000");
            Assert.AreEqual(ans, res);
        }
    }
}
