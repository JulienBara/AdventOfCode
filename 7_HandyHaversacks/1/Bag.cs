using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace _7_HandyHaversacks_1
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

        public List<(string,int)> Targets => Regex
            .Match(_toParse, @"contain (?<names>.+).")
            .Groups["names"]
            .Value
            .Split(", ")
            .Select(x => Regex.Match(x, @"(?<count>\d) (?<name>.+) bag").Groups)
            .Select(x => (x["name"].Value, int.Parse(x["count"].Value)))
            .Where(x => x.Item1 != String.Empty)
            .ToList();
    }
}