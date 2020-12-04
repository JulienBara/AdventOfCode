using System;
using System.IO;
using System.Linq;

namespace _4_PassportProcessing_1
{
    class Program
    {
        public const string InputFile = @".\input";

        static void Main(string[] args)
        {
            var validPassportsCount = File
                .ReadAllText(InputFile)
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => new Passport {String = x})
                .Where(x => x.IsValid)
                .Count()
            ;

            System.Console.WriteLine(validPassportsCount);
        }
    }
}
