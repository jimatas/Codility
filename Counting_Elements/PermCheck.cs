using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

/*
A non-empty array A consisting of N integers is given.

A permutation is a sequence containing each element from 1 to N once, and only once.

For example, array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2

is a permutation, but array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3

is not a permutation, because value 2 is missing.

The goal is to check whether array A is a permutation.

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A, returns 1 if array A is a permutation and 0 if it is not.

For example, given array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2

the function should return 1.

Given array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3

the function should return 0.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [1..1,000,000,000].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
 */

namespace Counting_Elements
{
    [TestClass]
    public class PermCheck
    {
        [TestMethod]
        public void Test1()
        {
            int actual = solution(new[] { 4, 1, 3, 2 });
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            int actual = solution(new[] { 4, 1, 3 });
            const int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            return Convert.ToInt32(!Enumerable.Range(1, A.Length).Except(A).Any());
        }
    }
}
