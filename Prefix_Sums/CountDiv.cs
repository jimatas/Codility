﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
Write a function:

    class Solution { public int solution(int A, int B, int K); }

that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

    { i : A ≤ i ≤ B, i mod K = 0 }

For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

Write an efficient algorithm for the following assumptions:

        A and B are integers within the range [0..2,000,000,000];
        K is an integer within the range [1..2,000,000,000];
        A ≤ B.

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/

namespace Prefix_Sums
{
    [TestClass]
    public class CountDiv
    {
        [DataTestMethod]
        [DataRow(6, 11, 2, 3)]
        [DataRow(7, 12, 2, 3)]
        public void Test(int A, int B, int K, int expected)
        {
            int actual = solution(A, B, K);

            Assert.AreEqual(expected, actual);
        }

        public int solution(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int result = B / K - A / K;
            if (A % K == 0)
            {
                result++;
            }
            return result;
        }
    }
}
