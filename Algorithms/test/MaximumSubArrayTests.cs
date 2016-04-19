using NUnit.Framework;
using System;

namespace Algorithms.MaximumSubArray.Tests
{
    public class MaximumSubArrayTests
    {
        static Type[] types =
        {
            typeof(NlgN),
            typeof(Nsquared),
            typeof(Linear)
        };

        void BaseTest(Type type, MaxSubArray expected, params int[] values)
        {
            var searcher = Activator.CreateInstance(type) as ISearcher;
            var r = searcher.Search(values);
            Assert.AreEqual(expected.Start, r.Start, "Start index differs");
            Assert.AreEqual(expected.End, r.End, "End index differs");
            Assert.AreEqual(expected.Sum, r.Sum, "Sum value differs");
        }

        MaxSubArray Expected(int start, int end, int sum)
        {
            return new MaxSubArray(start, end, sum);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_BookExample1(Type type)
        {
            BaseTest(type, Expected(7, 11, 43),
                100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_BookExample2(Type type)
        {
            BaseTest(type, Expected(2, 3, 3),
                10, 11, 7, 10, 6);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_AllIncreasing(Type type)
        {
            BaseTest(type, Expected(0, 4, 4),
                1, 2, 3, 4, 5);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_AllDecreasing(Type type)
        {
            BaseTest(type, MaxSubArray.None,
                31, 22, 14, 5, 4);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_AllDecreasing_FlatZone(Type type)
        {
            BaseTest(type, MaxSubArray.None,
                31, 22, 14, 14, 4);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_AllSame(Type type)
        {
            BaseTest(type, MaxSubArray.None,
                31, 31, 31, 31, 31);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_Empty(Type type)
        {
            BaseTest(type, MaxSubArray.None);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_SingleItem(Type type)
        {
            BaseTest(type, MaxSubArray.None,
                5);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_TwoItems_Increasing(Type type)
        {
            BaseTest(type, Expected(0, 1, 5),
                3, 8);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_ThreeItems_Increasing(Type type)
        {
            BaseTest(type, Expected(0, 2, 4),
                3, 5, 7);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_ThreeItems_DecreaseThenIncrease(Type type)
        {
            BaseTest(type, Expected(1, 2, 4),
                5, 4, 8);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_ThreeItems_IncreaseThenDecrease(Type type)
        {
            BaseTest(type, Expected(0, 1, 3),
                7, 10, 8);
        }

        [TestCaseSource("types")]
        public void MaximumSubArray_DecreasingOverall(Type type)
        {
            BaseTest(type, Expected(1, 4, 7),
                100, 65, 68, 67, 72, 66, 54);
        }
    }
}
