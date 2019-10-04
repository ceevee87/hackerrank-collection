using HackerRankCollection.ProblemSolutions;
using System.Numerics;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class ExtraLongFactorialTests
    {
        [TestCase(0)]
        [TestCase(1)]
        public void BaseCase(int n)
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(n);
            Assert.AreEqual(new BigInteger(1), res);
        }

        [Test]
        public void Test50()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(50);
            BigInteger ans = BigInteger.Parse("30414093201713378043612608166064768844377641568960512000000000000");
            Assert.AreEqual(ans, res);
        }

        [Test]
        public void Test25()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(25);
            BigInteger ans = BigInteger.Parse("15511210043330985984000000");
            Assert.AreEqual(ans, res);
        }

        [Test]
        public void Test30()
        {
            BigInteger res = ExtraLongFactorials.CalcExtraLongFactorial(30);
            BigInteger ans = BigInteger.Parse("265252859812191058636308480000000");
            Assert.AreEqual(ans, res);
        }
    }
}
