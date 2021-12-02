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

        public List<(string,int)> Targets => Regex
            .Match(_toParse, @"contain (?<names>.+).")
            .Groups["names"]
            .Value
            .Split(", ")
            .Select(x => Regex.Match(x, @"(?<count>\d) (?<name>.+) bag").Groups)
            .Where(x => x["name"].Value != String.Empty)
            .Select(x => (x["name"].Value, int.Parse(x["count"].Value)))
            .ToList();
    }
}