using System;
using System.IO;
using System.Linq;

namespace _6_CustomCustoms_2
{
    class Program
    {
        public const string InputFile = @".\input";

        static void Main(string[] args)
        {
            var sumCountDifferentYes = File
                .ReadAllText(InputFile)
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => new Group {String = x})
                .Sum(x => x.NumberOfDifferentYes)
                ;

            System.Console.WriteLine(sumCountDifferentYes);
        }
    }
}
