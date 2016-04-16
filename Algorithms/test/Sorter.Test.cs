using NUnit.Framework;
using System;

namespace Algorithms
{
    public class SorterTests
    {
        ISorter NewSorter(Type sorterType)
        {
            var sorter = Activator.CreateInstance(sorterType) as ISorter;
            return sorter;
        }

        void BaseTest(Type sorterType, int[] input, int[] expected)
        {
            ISorter sorter = NewSorter(sorterType);
            sorter.Sort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        int[] a(params int[] args) => args;

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_BookOrder(Type sorterType)
        {
            BaseTest(sorterType, a(5, 2, 4, 6, 1, 3), a(1, 2, 3, 4, 5, 6));
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_InOrder(Type sorterType)
        {
            BaseTest(sorterType, a(1, 2, 3, 4, 5, 6), a(1, 2, 3, 4, 5, 6));
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_ReverseOrder(Type sorterType)
        {
            BaseTest(sorterType, a(6, 5, 4, 3, 2, 1), a(1, 2, 3, 4, 5, 6));
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_EmptyList(Type sorterType)
        {
            BaseTest(sorterType, a(), a());
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_SingleItem(Type sorterType)
        {
            BaseTest(sorterType, a(6), a(6));
        }
    }
}
