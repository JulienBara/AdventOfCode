using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _7_HandyHaversacks_2
{
    public class Bag
    {
        private string _toParse;

        public Bag(string toParse)
        {
            _toParse = toParse;
        }

        public string Name => Regex
            .Match(_toParse, @"(?<name>.+) bags contain")
            .Groups["name"]
            .Value;

        public List<string> Targets => Regex
            .Match(_toParse, @"contain (?<names>.+).")
            .Groups["names"]
            .Value
            .Split(", ")
            .Select(x => Regex.Match(x, @"\d (?<name>.+) bag").Groups["name"].Value)
            .Where(x => x != String.Empty)
            .ToList();
    }
}