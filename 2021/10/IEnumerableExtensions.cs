using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class IEnumerableExtensions
    {
        public static TSource Median<TSource>(this IEnumerable<TSource> source)
        {
            var sortedArray = source.OrderBy(x => x).ToList();
            return sortedArray.ElementAt(sortedArray.Count / 2); // works only for odd-lentgh-long arrays
        }
    }
}
