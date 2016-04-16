using System;
using System.Collections.Generic;

namespace Algorithms.Searching
{
    interface ISearcher
    {
        int Search<T, Key>(IList<T> items, Key searchFor, Func<T, Key, int> comp);
    }
}
