namespace Algorithms.MaximumSubArray
{
    class MaxSubArray
    {
        public static readonly MaxSubArray None = new MaxSubArray(-1, -1, 0);

        public MaxSubArray(int start, int end, int sum)
        {
            Start = start;
            End = end;
            Sum = sum;
        }

        public int Start;
        public int End;
        public int Sum;
    }

    interface ISearcher
    {
        MaxSubArray Search(int[] values);
    }
}
