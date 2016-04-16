﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms
{
    [TestClass]
    public class SorterTests
    {
        public TestContext TestContext { get; set; }

        ISorter NewSorter()
        {
            string sorterType = TestContext.DataRow["sorter"].ToString();
            ISorter sorter = Activator.CreateInstance(Type.GetType(sorterType)) as ISorter;
            return sorter;
        }

        [TestMethod]
        public void Sort_BookOrder()
        {
            ISorter sorter = NewSorter();
            int[] array = { 5, 2, 4, 6, 1, 3 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6};
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void Sort_InOrder()
        {
            var sorter = NewSorter();
            int[] array = { 1, 2, 3, 4, 5, 6 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "c:\\projects\\cs\\algorithms\\algorithms\\data\\TestData.xml", "sorters", DataAccessMethod.Sequential)]
        public void Sort_ReverseOrder()
        {
            var sorter = NewSorter();
            int[] array = { 6, 5, 4, 3, 2, 1 };
            sorter.Sort(array);

            int[] expected = { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(expected, array);
        }
    }
}
