namespace Algorithms.MaximumSubArray
{
    abstract class SearcherBase : ISearcher
    {
        protected abstract MaxSubArray Search(int[] values, int start, int end);

        public MaxSubArray Search(int[] values)
        {
            if (values.Length <= 1)
                return MaxSubArray.NoResult;

            values = Tansform(values);

            var r = Search(values, 0, values.Length);
            return r.Sum < 1 ? MaxSubArray.NoResult : r;
        }

        private static int[] Tansform(int[] values)
        {
            var t = new int[values.Length - 1];

            for (var i = 0; i < t.Length; i++)
                t[i] = values[i + 1] - values[i];

            return t;
        }
    }
}
