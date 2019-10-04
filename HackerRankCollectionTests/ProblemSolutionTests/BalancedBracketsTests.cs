using HackerRankCollection.ProblemSolutions;
using NUnit.Framework;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestFixture]
    public class BalancedBracketsTests
    {
        [TestCase("{[()]}")]
        [TestCase("{{[[(())]]}}")]
        [TestCase("{{([])}}")]
        [TestCase("{(([])[])[]}")]
        [TestCase("{(([])[])[]}[]")]
        // [DataTestMethod]
        public void ParamBracketsMatch(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("YES", res);
        }

        [TestCase("{[(])}")]
        [TestCase("{{[{(())]]}}")]
        [TestCase("{(([])[])[]]}")]
        [TestCase("{{)[](}}")]
        // [DataTestMethod]
        public void ParamBracketsDoNotMatch(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("NO", res);
        }

        [TestCase("])}")]
        [TestCase("(")]
        // [DataTestMethod]
        public void ParamBracketsDoNotMatchTricky(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("NO", res);
        }
    }
}
