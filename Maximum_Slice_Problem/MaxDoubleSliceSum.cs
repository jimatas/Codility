using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

/*
A non-empty array A consisting of N integers is given.

A triplet (X, Y, Z), such that 0 ≤ X < Y < Z < N, is called a double slice.

The sum of double slice (X, Y, Z) is the total of A[X + 1] + A[X + 2] + ... + A[Y − 1] + A[Y + 1] + A[Y + 2] + ... + A[Z − 1].

For example, array A such that:
    A[0] = 3
    A[1] = 2
    A[2] = 6
    A[3] = -1
    A[4] = 4
    A[5] = 5
    A[6] = -1
    A[7] = 2

contains the following example double slices:

        double slice (0, 3, 6), sum is 2 + 6 + 4 + 5 = 17,
        double slice (0, 3, 7), sum is 2 + 6 + 4 + 5 − 1 = 16,
        double slice (3, 4, 5), sum is 0.

The goal is to find the maximal sum of any double slice.

Write a function:

    class Solution { public int solution(int[] A); }

that, given a non-empty array A consisting of N integers, returns the maximal sum of any double slice.

For example, given:
    A[0] = 3
    A[1] = 2
    A[2] = 6
    A[3] = -1
    A[4] = 4
    A[5] = 5
    A[6] = -1
    A[7] = 2

the function should return 17, because no double slice of array A has a sum of greater than 17.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [3..100,000];
        each element of array A is an integer within the range [−10,000..10,000].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
 */

namespace Maximum_Slice_Problem
{
    [TestClass]
    public class MaxDoubleSliceSum
    {
        [TestMethod]
        public void Test1()
        {
            int actual = solution(new[] { 3, 2, 6, -1, 4, 5, -1, 2 });
            const int expected = 17;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {

            int actual = solution(new[] { 5, 17, 0, 3 });
            const int expected = 17;

            Assert.AreEqual(expected, actual);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int[] sumsEndingAt = new int[A.Length];
            for (int i = 1; i < A.Length - 1; i++)
            {
                sumsEndingAt[i] = Math.Max(0, sumsEndingAt[i - 1] + A[i]);
            }

            int[] sumsStartingAt = new int[A.Length];
            for (int i = A.Length - 2; i > 0; i--)
            {
                sumsStartingAt[i] = Math.Max(0, sumsStartingAt[i + 1] + A[i]);
            }

            int maxSum = 0;
            for (int i = 1; i < sumsEndingAt.Length - 1; i++)
            {
                maxSum = Math.Max(maxSum, sumsEndingAt[i - 1] + sumsStartingAt[i + 1]);
            }
            return maxSum;
        }
    }
}
