using HackerRankCollection.ProblemSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankCollectionTests.ProblemSolutionTests
{
    [TestClass]
    public class BalancedBracketsTests
    {
        [DataRow("{[()]}")]
        [DataRow("{{[[(())]]}}")]
        [DataRow("{{([])}}")]
        [DataRow("{(([])[])[]}")]
        [DataRow("{(([])[])[]}[]")]
        [DataTestMethod]
        public void ParamBracketsMatch(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("YES", res);
        }

        [DataRow("{[(])}")]
        [DataRow("{{[{(())]]}}")]
        [DataRow("{(([])[])[]]}")]
        [DataRow("{{)[](}}")]
        [DataTestMethod]
        public void ParamBracketsDoNotMatch(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("NO", res);
        }

        [DataRow("])}")]
        [DataRow("(")]
        [DataTestMethod]
        public void ParamBracketsDoNotMatchTricky(string s)
        {
            string res = BalancedBrackets.isBalanced(s);
            Assert.AreEqual("NO", res);
        }
    }
}
