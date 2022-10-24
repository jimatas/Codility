using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

/*
This is a demo task.

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 
*/

namespace Counting_Elements
{
    [TestClass]
    public class MissingInteger
    {
        [TestMethod]
        public void Test1()
        {
            int actual = solution(new[] { 1, 3, 6, 4, 1, 2 });
            const int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            int actual = solution(new[] { 1, 2, 3 });
            const int expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            int actual = solution(new[] { -1, -3 });
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            int[] sortedPositiveIntegers = A.Where(a => a > 0).OrderBy(a => a).Distinct().ToArray();

            if (sortedPositiveIntegers.Length == 0)
            {
                return 1;
            }

            int maxValue = sortedPositiveIntegers[sortedPositiveIntegers.Length - 1];
            int[] difference = Enumerable.Range(1, maxValue).Except(sortedPositiveIntegers).ToArray();

            return difference.Any() ? difference.First() : maxValue + 1;
        }
    }
}
