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
            var bufferLength = secondSortedIndex - firstSortedIndex;
            var buffer = new int[bufferLength];
            for (var copyIndex = 0; copyIndex < bufferLength; copyIndex++)
                buffer[copyIndex] = array[firstSortedIndex + copyIndex];

            var bufferIndex = 0;
            for (var i = firstSortedIndex; i < lastIndex; i++)
            {
                if (bufferIndex == bufferLength)
                    return; // Everything in the second list should already be in the correct place
                else if (secondSortedIndex == lastIndex)
                {
                    for (; i < lastIndex; i++)
                        array[i] = buffer[bufferIndex++];
                    return;
                }
                else if (buffer[bufferIndex] < array[secondSortedIndex])
                    array[i] = buffer[bufferIndex++];
                else
                    array[i] = array[secondSortedIndex++];
            }
        }
    }
}
