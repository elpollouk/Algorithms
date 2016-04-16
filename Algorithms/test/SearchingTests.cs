using NUnit.Framework;
using System;

namespace Algorithms.Searching.Tests
{
    class SearchingTests
    {
        static int Compare(int listItem, int target) =>  listItem - target;
        static void NotFound(int i) => Assert.AreEqual(-1, i);
        static Action<int> FoundAt(int index) => i => Assert.AreEqual(index, i);

        void BaseTest(Type searcherType, Action<int> validate, int searchFor, params int[] values)
        {
            var searcher = Activator.CreateInstance(searcherType) as ISearcher;
            var result = searcher.Search(values, searchFor, Compare);
            validate(result);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_NoItems(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                4);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_OneItem_NotFound(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                4,
                1);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_OneItem_FoundAt0(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(0),
                4,
                4);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_TwoItems_NotFound(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                4,
                1, 2);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_TwoItem_FoundAt0(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(0),
                1,
                1, 2);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_TwoItem_FoundAt1(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(1),
                2,
                1, 2);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_ThreeItems_NotFound(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                4,
                1, 2, 3);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_ThreeItem_FoundAt0(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(0),
                1,
                1, 2, 3);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_ThreeItem_FoundAt1(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(1),
                2,
                1, 2, 3);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_ThreeItem_FoundAt2(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(2),
                3,
                1, 2, 3);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FourItems_NotFound(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                4,
                1, 2, 3, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FourItem_FoundAt0(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(0),
                1,
                1, 2, 3, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FourItem_FoundAt1(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(1),
                2,
                1, 2, 3, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FourItem_FoundAt2(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(2),
                3,
                1, 2, 3, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FourItem_FoundAt3(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(3),
                5,
                1, 2, 3, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItems_NotFound(Type searcherType)
        {
            BaseTest(searcherType,
                NotFound,
                0,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItem_FoundAt0(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(0),
                1,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItem_FoundAt1(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(1),
                2,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItem_FoundAt2(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(2),
                3,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItem_FoundAt3(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(3),
                4,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_FiveItem_FoundAt4(Type searcherType)
        {
            BaseTest(searcherType,
                FoundAt(4),
                5,
                1, 2, 3, 4, 5);
        }

        [TestCase(typeof(LinearSearch))]
        [TestCase(typeof(BinarySearch))]
        public void Search_500Items(Type searcherType)
        {
            var rnd = new Random();
            for (var i = 0; i < 500; i++)
            {
                var nextValue = rnd.Next(4);
                var values = new int[500];
                for (var j = 0; j < values.Length; j++)
                {
                    values[j] = nextValue;
                    nextValue += rnd.Next(3) + 1;
                }

                BaseTest(searcherType,
                    FoundAt(i),
                    values[i],
                    values);
            }
        }
    }
}
