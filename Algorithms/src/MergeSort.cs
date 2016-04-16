using System;

namespace Algorithms
{
    class MergeSort : ISorter
    {
        public void Sort(int[] array)
        {
            if (array.Length <= 1) return;
            Sort(array, 0, array.Length / 2, array.Length);
        }

        private static void Sort(int[] array, int leftStart, int rightStart, int lastIndex)
        {
            if (leftStart + 1 == lastIndex) return;

            var mid = (rightStart - leftStart) / 2;
            mid += leftStart;
            Sort(array, leftStart, mid, rightStart);

            mid = (lastIndex - rightStart) / 2;
            mid += rightStart;
            Sort(array, rightStart, mid, lastIndex);

            Merge(array, leftStart, rightStart, lastIndex);
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
