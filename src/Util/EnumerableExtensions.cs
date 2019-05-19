using System;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> EveryN<T>(this IEnumerable<T> input, int step)
        {
            return input.Where((x, i) => i % step == 0);
        }
    }
}