using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

/*
An array A consisting of N integers is given. The dominator of array A is the value that occurs in more than half of the elements of A.

For example, consider array A such that
 A[0] = 3    A[1] = 4    A[2] =  3
 A[3] = 2    A[4] = 3    A[5] = -1
 A[6] = 3    A[7] = 3

The dominator of A is 3 because it occurs in 5 out of 8 elements of A (namely in those with indices 0, 2, 4, 6 and 7) and 5 is more than a half of 8.

Write a function

    class Solution { public int solution(int[] A); }

that, given an array A consisting of N integers, returns index of any element of array A in which the dominator of A occurs. The function should return −1 if array A does not have a dominator.

For example, given array A such that
 A[0] = 3    A[1] = 4    A[2] =  3
 A[3] = 2    A[4] = 3    A[5] = -1
 A[6] = 3    A[7] = 3

the function may return 0, 2, 4, 6 or 7, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [0..100,000];
        each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
 */

namespace Leader
{
    [TestClass]
    public class Dominator
    {
        [TestMethod]
        public void Test()
        {
            int actual = solution(new[] { 3, 4, 3, 2, 3, -1, 3, 3 });
            int[] expected = new[] { 0, 2, 4, 6, 7 };

            Assert.IsTrue(expected.Contains(actual));
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)

            if (A.Length == 0) return -1;
            if (A.Length == 1) return 0;

            Item[] a = A.Select((value, index) => new Item(value, index)).OrderBy(i => i.Value).ToArray();

            int count = 1;
            int longestCount = 1;
            int lastIndexOfLongestCountItem = -1;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i].Value == a[i - 1].Value)
                {
                    count++;
                }
                else
                {
                    if (count > longestCount)
                    {
                        lastIndexOfLongestCountItem = a[i - 1].Index;
                        longestCount = count;
                    }
                    count = 1;
                }
            }

            if (count > longestCount)
            {
                lastIndexOfLongestCountItem = a[a.Length - 1].Index;
                longestCount = count;
            }

            return longestCount > a.Length / 2 ? lastIndexOfLongestCountItem : -1;
        }

        struct Item
        {
            public Item(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public int Value { get; }
            public int Index { get; }
        }
    }
}
