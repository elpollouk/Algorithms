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

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_BookOrder(Type sorterType)
        {
            ISorter sorter = NewSorter(sorterType);
            int[] array = { 5, 2, 4, 6, 1, 3 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6};
            CollectionAssert.AreEqual(expected, array);
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_InOrder(Type sorterType)
        {
            var sorter = NewSorter(sorterType);
            int[] array = { 1, 2, 3, 4, 5, 6 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(expected, array);
        }

        [TestCase(typeof(InsertionSort))]
        [TestCase(typeof(SelectionSort))]
        public void Sort_ReverseOrder(Type sorterType)
        {
            var sorter = NewSorter(sorterType);
            int[] array = { 6, 5, 4, 3, 2, 1 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(expected, array);
        }
    }
}
