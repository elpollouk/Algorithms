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
            var bufferLeft = new int[leftLength];
            for (var copyIndex = 0; copyIndex < leftLength; copyIndex++)
                bufferLeft[copyIndex] = array[firstSortedIndex + copyIndex];

            var bufferLeftIndex = 0;
            for (var i = firstSortedIndex; i < lastIndex; i++)
            {
                if (bufferLeftIndex == bufferLeft.Length)
                    return; // Everything in the second list should already be in the correct place
                else if (secondSortedIndex == lastIndex)
                {
                    for (; i < lastIndex; i++)
                        array[i] = bufferLeft[bufferLeftIndex++];
                    return;
                }
                else if (bufferLeft[bufferLeftIndex] < array[secondSortedIndex])
                    array[i] = bufferLeft[bufferLeftIndex++];
                else
                    array[i] = array[secondSortedIndex++];
            }
        }
    }
}
