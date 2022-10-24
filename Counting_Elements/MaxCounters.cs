﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

/*
You are given N counters, initially set to 0, and you have two possible operations on them:

        increase(X) − counter X is increased by 1,
        max counter − all counters are set to the maximum value of any counter.

A non-empty array A of M integers is given. This array represents consecutive operations:

        if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
        if A[K] = N + 1 then operation K is max counter.

For example, given integer N = 5 and array A such that:
    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the values of the counters after each consecutive operation will be:
    (0, 0, 1, 0, 0)
    (0, 0, 1, 1, 0)
    (0, 0, 1, 2, 0)
    (2, 2, 2, 2, 2)
    (3, 2, 2, 2, 2)
    (3, 2, 2, 3, 2)
    (3, 2, 2, 4, 2)

The goal is to calculate the value of every counter after all operations.

Write a function:

    class Solution { public int[] solution(int N, int[] A); }

that, given an integer N and a non-empty array A consisting of M integers, returns a sequence of integers representing the values of the counters.

Result array should be returned as an array of integers.

For example, given:
    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the function should return [3, 2, 2, 4, 2], as explained above.

Write an efficient algorithm for the following assumptions:

        N and M are integers within the range [1..100,000];
        each element of array A is an integer within the range [1..N + 1].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
*/

namespace Counting_Elements
{
    [TestClass]
    public class MaxCounters
    {
        [TestMethod]
        public void Test1()
        {
            int[] actual = solution(5, new[] { 3, 4, 4, 6, 1, 4, 4 });
            int[] expected = new[] { 3, 2, 2, 4, 2 };

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void Test2()
        {
            int[] actual = solution(5, new[] { 1, 6, 6, 6, 6, 6, 6 });
            int[] expected = new[] { 1, 1, 1, 1, 1 };

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        public int[] solution(int N, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int[] counters = new int[N];
            
            int maxValue = 0;
            int previousMaxValue = 0;

            foreach (var operation in A)
            {
                if (operation <= N)
                {
                    maxValue = Math.Max(maxValue, ++counters[operation - 1]);
                }
                else if (maxValue != previousMaxValue)
                {
                    for (var j = 0; j < N; j++)
                    {
                        counters[j] = maxValue;
                    }
                    previousMaxValue = maxValue;
                }
            }

            return counters;
        }
    }
}
