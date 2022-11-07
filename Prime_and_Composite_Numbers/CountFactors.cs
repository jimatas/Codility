using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

/*
A positive integer D is a factor of a positive integer N if there exists an integer M such that N = D * M.

For example, 6 is a factor of 24, because M = 4 satisfies the above condition (24 = 6 * 4).

Write a function:

    class Solution { public int solution(int N); }

that, given a positive integer N, returns the number of its factors.

For example, given N = 24, the function should return 8, because 24 has 8 factors, namely 1, 2, 3, 4, 6, 8, 12, 24. There are no other factors of 24.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..2,147,483,647].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/

namespace Prime_and_Composite_Numbers
{
    [TestClass]
    public class CountFactors
    {
        [DataTestMethod]
        [DataRow(24, 8)]
        [DataRow(10, 4)]
        [DataRow(16, 5)]
        public void Test(int N, int expected)
        {
            int actual = solution(N);

            Assert.AreEqual(expected, actual);
        }

        public int solution(int N)
        {
            int factors = 0;
            int sqrtN = (int)Math.Ceiling(Math.Sqrt(N));

            for (int i = 1; i < sqrtN; i++)
            {
                if (N % i == 0)
                {
                    factors += 2;
                }
            }

            if (sqrtN * sqrtN == N)
            {
                factors++;
            }

            return factors;
        }
    }
}
