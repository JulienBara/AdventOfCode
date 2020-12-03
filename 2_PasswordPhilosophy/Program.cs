using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2_PasswordPhilosophy
{
    class Program
    {
        public const string InputFile = @".\input";
        public static Regex ParsingRegex = new Regex(@"(?<min>\d+)-(?<max>\d+)\s(?<char>\w+):\s(?<password>\w+)");

        static void Main(string[] args)
        {
            var countValidPolicies = File
                .ReadAllLines(InputFile)
                .Select(x => ParsingRegex.Match(x))
                .Select(x => new Policy{
                    MinChar = Int32.Parse(x.Groups["min"].Value),
                    MaxChar = Int32.Parse(x.Groups["max"].Value),
                    Char = x.Groups["char"].Value[0],
                    Password = x.Groups["password"].Value
                })
                .Where(x => x.IsValid())
                .Count();

                System.Console.WriteLine(countValidPolicies);
        }
    }
}
