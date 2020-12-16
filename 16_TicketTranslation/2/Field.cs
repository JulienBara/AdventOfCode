using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace _16_TicketTranslation_2
{
    public class Field
    {
        public string String { get; set; }

        public static Regex RangesRegex = new Regex(@"(?<startRange>\d+?)-(?<endRange>\d+?)\b");
        public IEnumerable<(int, int)> Ranges => RangesRegex
            .Matches(String)
            .Select(x => (x.Groups["startRange"].Value,x.Groups["endRange"].Value))
            .Select(x => (int.Parse(x.Item1), int.Parse(x.Item2)));

        public Func<int, bool> Validator => 
            (number) => Ranges.Any(x => x.Item1 <= number && number <= x.Item2);
    }
}