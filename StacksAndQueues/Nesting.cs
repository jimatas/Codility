using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

/*
A string S consisting of N characters is called properly nested if:

        S is empty;
        S has the form "(U)" where U is a properly nested string;
        S has the form "VW" where V and W are properly nested strings.

For example, string "(()(())())" is properly nested but string "())" isn't.

Write a function:

    class Solution { public int solution(string S); }

that, given a string S consisting of N characters, returns 1 if string S is properly nested and 0 otherwise.

For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [0..1,000,000];
        string S is made only of the characters "(" and/or ")".

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
 */

namespace StacksAndQueues
{
    [TestClass]
    public class Nesting
    {
        [DataTestMethod]
        [DataRow("(()(())())", 1)]
        [DataRow("())", 0)]
        public void Test(string S, int expected)
        {
            int actual = solution(S);

            Assert.AreEqual(expected, actual);
        }

        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            Stack<char> stack = new Stack<char>();
            foreach (char c in S)
            {
                if (c == ')')
                {
                    if (!stack.Any() || stack.Pop() != '(')
                    {
                        return 0;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }
    }
}
