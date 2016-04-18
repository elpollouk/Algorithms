namespace Algorithms.MaximumSubArray
{
    class Linear : SearcherBase
    {
        protected override MaxSubArray Search(int[] values, int start, int end)
        {
            var max = new MaxSubArray(0, 0, 0);
            var currentStreakMax = 0;
            var currentStreakSum = 0;
            var currentStreakStart = 0;
            var currentStreakEnd = 0;

            for (var i = 0; i < values.Length; i++)
            {
                var t = currentStreakSum + values[i];
                if (t <= 0)
                {
                    if (max.Sum < currentStreakMax)
                    {
                        max.Sum = currentStreakMax;
                        max.Start = currentStreakStart;
                        max.End = currentStreakEnd + 1;
                    }
                    currentStreakMax = 0;
                    currentStreakSum = 0;
                    currentStreakStart = i + 1;
                    currentStreakEnd = currentStreakStart;
                }
                else
                {
                    currentStreakSum = t;
                    if (currentStreakMax < currentStreakSum)
                    {
                        currentStreakMax = currentStreakSum;
                        currentStreakEnd = i;
                    }
                }
            }

            if (max.Sum < currentStreakMax)
            {
                max.Sum = currentStreakMax;
                max.Start = currentStreakStart;
                max.End = currentStreakEnd + 1;
            }

            return max;
        }
    }
}
