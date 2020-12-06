using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_CustomCustoms_2
{
    public class Group
    {
        private string _toParse;

        public Group(string toParse)
        {
            _toParse = toParse;
        }

        public List<string> PassengersStrings => _toParse
            .Split(Environment.NewLine)
            .ToList();

        public int NumberOfDifferentYes => PassengersStrings
            .First()
            .Where(character => PassengersStrings
                .All(passengerString => passengerString.Contains(character)))
            .Count();
    }
}
