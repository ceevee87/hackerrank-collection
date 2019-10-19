using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions
{
    class BracketStack
    {
        private List<char> _stack;
        public BracketStack()
        {
            _stack = new List<char>();
        }
        public void Push(char c)
        {
            _stack.Insert(0, c);
        }

        public bool IsEmpty()
        {
            return (_stack.Count == 0);
        }
        public bool CanPop(char c)
        {
            if (_stack.Count == 0) return false;
            char TopItemInStack = _stack.ElementAt(0);

            if (c == ']' && TopItemInStack == '[') return true;
            if (c == ')' && TopItemInStack == '(') return true;
            if (c == '}' && TopItemInStack == '{') return true;
            return false;
        }

        public char Pop()
        {
            char res = _stack.ElementAt(0);
            _stack.RemoveAt(0);
            return res;
        }
    }

    public static class BalancedBrackets
    {
        public static string isBalanced(string s)
        {
            var bracketStack = new BracketStack();
            int discard;
            foreach (char c in s)
            {
                if (c == '{' || c == '(' || c == '[')
                {
                    bracketStack.Push(c);
                    continue;
                }
                if (c == '}' || c == ')' || c == ']')
                {
                    if (bracketStack.CanPop(c))
                    {
                        discard = bracketStack.Pop();
                    } else
                    {
                        return "NO";
                    }
                }
            }
           
            return (bracketStack.IsEmpty()) ? "YES" : "NO";
        }
    }

}
