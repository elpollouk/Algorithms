namespace Algorithms.MaximumSubArray
{
    struct MaxSubArray
    {
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
