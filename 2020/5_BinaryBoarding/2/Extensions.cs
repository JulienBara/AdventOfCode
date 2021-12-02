using System;
using System.Runtime.CompilerServices;

namespace _5_BinaryBoarding_2
{
    public static class Extensions
    {
        public static int ToInt(this string bin_strng, int fromBase) => Convert.ToInt32(bin_strng, fromBase);
    }
}