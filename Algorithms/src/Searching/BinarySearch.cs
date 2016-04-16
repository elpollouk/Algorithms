using System;
using System.Collections.Generic;

namespace Algorithms.Searching
{
    class BinarySearch : ISearcher
    {
        public int Search<T, Key>(IList<T> items, Key searchFor, Func<T, Key, int> comp)
        {
            var lower = 0;
            var upper = items.Count;

            while (lower < upper)
            {
                var mid = (lower + upper) / 2;
                var r = comp(items[mid], searchFor);
                if (r == 0)
                    return mid;
                else if (r < 0)
                    lower = mid + 1;
                else
                    upper = mid;
            }

            return -1;
        }
    }
}
