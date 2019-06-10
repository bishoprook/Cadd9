using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadd9.Util
{
    ///<summary>
    ///  Adds useful extension methods to <see cref="IEnumerable{T}"/>
    ///</summary>
    public static class EnumerableExtensions
    {
        ///<summary>
        ///  Returns the first element in the input and every Nth afterward.
        ///</summary>
        ///<example>
        ///  This example demonstrates how to use <see cref="EveryN{T}"/> to take every
        ///  Nth element of a range.
        ///<code>
        ///  var result = Enumerable.Range(1, 10).EveryN(3);
        ///  foreach (var num in result)
        ///  {
        ///      Console.WriteLine(num);
        ///  }
        ///  // This produces: 1, 4, 7, 10
        ///</code>
        ///</example>
        public static IEnumerable<T> EveryN<T>(this IEnumerable<T> input, int step)
        {
            return input.Where((x, i) => i % step == 0);
        }
    }
}