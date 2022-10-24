using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

/*
A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.

Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

For example, consider array A such that:
  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3

We can split this tape in four places:

        P = 1, difference = |3 − 10| = 7
        P = 2, difference = |4 − 9| = 5
        P = 3, difference = |6 − 7| = 1
        P = 4, difference = |10 − 3| = 7

Write a function:

    class Solution { public int solution(int[] A); }

that, given a non-empty array A of N integers, returns the minimal difference that can be achieved.

For example, given:
  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3

the function should return 1, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [2..100,000];
        each element of array A is an integer within the range [−1,000..1,000].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/

namespace Time_Complexity
{
    [TestClass]
    public class TapeEquilibrium
    {
        [TestMethod]
        public void Test()
        {
            int actual = solution(new[] { 3, 1, 2, 4, 3 });
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int? minimalDifference = null;

            int sumOfLeftPart = 0;
            int? sumOfRightPart = null;

            for (int i = 1; i < A.Length; i++)
            {
                sumOfLeftPart += A[i - 1];
                if (sumOfRightPart == null)
                {
                    sumOfRightPart = 0;
                    for (int j = i; j < A.Length; j++)
                    {
                        sumOfRightPart += A[j];
                    }
                }
                else
                {
                    sumOfRightPart -= A[i - 1];
                }

                int difference = Math.Abs(sumOfLeftPart - (int)sumOfRightPart);

                if (minimalDifference == null)
                {
                    minimalDifference = difference;
                }
                else
                {
                    minimalDifference = Math.Min((int)minimalDifference, difference);
                }
            }

            return minimalDifference ?? 0;
        }
    }
}
