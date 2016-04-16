using System;
using System.Collections.Generic;

namespace Algorithms.Searching
{
    class LinearSearch : ISearcher
    {
        public int Search<T, Key>(IList<T> items, Key searchFor, Func<T, Key, int> comp)
        {
            for (var i = 0; i < items.Count; i++)
            {
                var r = comp(items[i], searchFor);
                if (r == 0)
                    return i;
                if (r > 0)
                    return -1;
            }
            return -1;
        }
    }
}
