﻿using NUnit.Framework;
using System;

namespace Algorithms.Sorting.Tests
{
    public class SortingTests
    {
        static Type[] types =
        {
            typeof(InsertionSort),
            typeof(SelectionSort),
            typeof(MergeSort),
            typeof(BubbleSort)
        };

        void BaseTest(Type sorterType, params int[] input)
        {
            var expected = input.Clone() as int[];
            Array.Sort(expected);

            var sorter = Activator.CreateInstance(sorterType) as ISorter;
            sorter.Sort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestCaseSource("types")]
        public void Sort_BookOrder(Type sorterType)
        {
            BaseTest(sorterType, 5, 2, 4, 6, 1, 3);
        }

        [TestCaseSource("types")]
        public void Sort_InOrder(Type sorterType)
        {
            BaseTest(sorterType, 1, 2, 3, 4, 5, 6);
        }

        [TestCaseSource("types")]
        public void Sort_ReverseOrder(Type sorterType)
        {
            BaseTest(sorterType, 6, 5, 4, 3, 2, 1);
        }

        [TestCaseSource("types")]
        public void Sort_EmptyList(Type sorterType)
        {
            BaseTest(sorterType);
        }

        [TestCaseSource("types")]
        public void Sort_SingleItem(Type sorterType)
        {
            BaseTest(sorterType, 6);
        }

        [TestCaseSource("types")]
        public void Sort_500Random(Type sorterType)
        {
            for (var i = 0; i < 500; i++)
            {
                var input = new int[500];
                var rnd = new Random();
                for (var j = 0; j < input.Length; j++)
                    input[j] = rnd.Next();

                BaseTest(sorterType, input);
            }
        }
    }
}
