using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
A non-empty array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road.

Array A contains only 0s and/or 1s:

        0 represents a car traveling east,
        1 represents a car traveling west.

The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.

For example, consider array A such that:
  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1

We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

Write a function:

    class Solution { public int solution(int[] A); }

that, given a non-empty array A of N integers, returns the number of pairs of passing cars.

The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

For example, given:
  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1

the function should return 5, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer that can have one of the following values: 0, 1.

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
 */

namespace Prefix_Sums
{
    [TestClass]
    public class PassingCars
    {
        [TestMethod]
        public void Test1()
        {
            int actual = solution(new[] { 0, 1, 0, 1, 1 });
            const int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            int actual = solution(new[] { 0, 1, 0, 1, 1, 0, 0, 1 });
            const int expected = 9;

            Assert.AreEqual(expected, actual);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int zeroes = 0;
            int onesPassed = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    zeroes++;
                } 
                else
                {
                    onesPassed += zeroes;
                }

                if (onesPassed > 1_000_000_000)
                {
                    return -1;
                }
            }
            return onesPassed;
        }
    }
}
