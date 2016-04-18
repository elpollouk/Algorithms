using System;

namespace Algorithms.MaximumSubArray
{
    class NlgN : SearcherBase
    {
        protected override MaxSubArray Search(int[] values, int start, int end)
        {
            if (start + 1 == end)
                return new MaxSubArray(start, end, values[start]);

            var mid = (start + end) / 2;

            var left = Search(values, start, mid);
            var right = Search(values, mid, end);
            var cross = MaxCrossingSubArray(values, start, mid, end);

            if (left.Sum >= right.Sum && left.Sum >= cross.Sum)
                return left;
            if (right.Sum >= left.Sum && right.Sum >= cross.Sum)
                return right;
            return cross;
        }

        static MaxSubArray MaxCrossingSubArray(int[] values, int start, int mid, int end)
        {
            var leftSum = Int32.MinValue;
            var sum = 0;
            var maxLeft = mid - 1;
            for (var i = mid - 1; i >= start; i--)
            {
                sum += values[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            var rightSum = Int32.MinValue;
            sum = 0;
            var maxRight = mid;
            for (var i = mid; i < end; i++)
            {
                sum += values[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return new MaxSubArray(maxLeft, maxRight + 1, leftSum + rightSum); // Need to add 1 to maxRight as it should indicate the exclusive end of the sub array
        }
    }
}
