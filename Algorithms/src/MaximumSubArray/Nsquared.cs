namespace Algorithms.MaximumSubArray
{
    class Nsquared : SearcherBase
    {
        protected override MaxSubArray Search(int[] values, int start, int end)
        {
            var max = new MaxSubArray(0, 0, 0);

            for (var i = 0; i < values.Length; i++)
            {
                var currentSum = 0;
                var currentMax = 0;
                var currentMaxStart = i;
                for (var j = i; j >= 0; j--)
                {
                    currentSum += values[j];
                    if (currentSum <= 0) break; // An opportunity to break out early as a negative/zero value indicates that any gains in this sub-array have already been wiped out
                    if (currentSum > currentMax)
                    {
                        currentMax = currentSum;
                        currentMaxStart = j;
                    }
                }

                if (currentMax > max.Sum)
                {
                    max.Sum = currentMax;
                    max.Start = currentMaxStart;
                    max.End = i + 1;
                }
            }

            return max;
        }
    }
}
