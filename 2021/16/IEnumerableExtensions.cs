using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class IEnumerableExtensions
    {
        public static string JoinStrings(this IEnumerable<string> source)
        {
            return String.Join("", source);
        }

        public static string JoinStrings(this IEnumerable<char> source)
        {
            return String.Join("", source);
        }
    }
}
