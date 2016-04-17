using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.test.Problems
{
    class InversionsProblem
    {
        public int Inversions(params int[] array)
        {
            if (array.Length <= 1) return 0;
            return Inversions(array, 0, array.Length);
        }

        private static int Inversions(int[] array, int subStart, int lastIndex)
        {
            if (subStart + 1 == lastIndex) return 0;

            var mid = (subStart + lastIndex) / 2;

            var li = Inversions(array, subStart, mid);
            var ri = Inversions(array, mid, lastIndex);
            var mi = MergeInversions(array, subStart, mid, lastIndex);

            return li + ri + mi;
        }

        private static int MergeInversions(int[] array, int firstSortedIndex, int secondSortedIndex, int lastIndex)
        {
            var bufferLength = secondSortedIndex - firstSortedIndex;
            var buffer = new int[bufferLength];
            for (var copyIndex = 0; copyIndex < bufferLength; copyIndex++)
                buffer[copyIndex] = array[firstSortedIndex + copyIndex];

            var moved = 0; // Number of higher indices moved down the array
            var total = 0; // moved * number of lower indices that are moved up the array

            var bufferIndex = 0;
            for (var i = firstSortedIndex; i < lastIndex; i++)
            {
                if (bufferIndex == bufferLength)
                    break;
                else if (secondSortedIndex == lastIndex)
                {
                    total += moved * (lastIndex - i);
                    for (; i < lastIndex; i++)
                        array[i] = buffer[bufferIndex++];
                    return total;
                }
                else if (buffer[bufferIndex] < array[secondSortedIndex])
                {
                    total += moved;
                    array[i] = buffer[bufferIndex++];
                }
                else
                {
                    moved++;
                    array[i] = array[secondSortedIndex++];
                }
            }

            return total;
        }

        [Test]
        public void InversionCheck()
        {
            Assert.AreEqual(5, Inversions(2, 3, 8, 6, 1));
            Assert.AreEqual(10, Inversions(5, 4, 3, 2, 1));
            Assert.AreEqual(1, Inversions(5, 4));
            Assert.AreEqual(0, Inversions());
            Assert.AreEqual(0, Inversions(1));
            Assert.AreEqual(0, Inversions(1, 2));
            Assert.AreEqual(0, Inversions(1, 2, 3));
        }
    }
}
