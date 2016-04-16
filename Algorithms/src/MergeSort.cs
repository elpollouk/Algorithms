using System;

namespace Algorithms
{
    class MergeSort : ISorter
    {
        public void Sort(int[] array)
        {
            if (array.Length <= 1) return; // Lists of 1 or less items are already sorted by definition
            Sort(array, 0, array.Length);
        }

        private static void Sort(int[] array, int subStart, int lastIndex)
        {
            if (subStart + 1 == lastIndex) return; // Lists of 1 item are already sorted

            var mid = (subStart + lastIndex) / 2;

            Sort(array, subStart, mid);
            Sort(array, mid, lastIndex);
            Merge(array, subStart, mid, lastIndex);
        }

        private static void Merge(int[] array, int firstSortedIndex, int secondSortedIndex, int lastIndex)
        {
            var leftLength = secondSortedIndex - firstSortedIndex;
            var bufferLeft = new int[leftLength + 1];
            bufferLeft[leftLength] = Int32.MaxValue;
            for (var copyIndex = 0; copyIndex < leftLength; copyIndex++)
                bufferLeft[copyIndex] = array[firstSortedIndex + copyIndex];

            var rightLength = lastIndex - secondSortedIndex;
            var bufferRight = new int[rightLength + 1];
            bufferRight[rightLength] = Int32.MaxValue;
            for (var copyIndex = 0; copyIndex < rightLength; copyIndex++)
                bufferRight[copyIndex] = array[secondSortedIndex + copyIndex];

            var bufferLeftIndex = 0;
            var bufferRightIndex = 0;
            for (var i = firstSortedIndex; i < lastIndex; i++)
            {
                if (bufferLeft[bufferLeftIndex] < bufferRight[bufferRightIndex])
                    array[i] = bufferLeft[bufferLeftIndex++];
                else
                    array[i] = bufferRight[bufferRightIndex++];
            }
        }
    }
}
