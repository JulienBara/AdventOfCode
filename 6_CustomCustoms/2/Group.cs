using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_CustomCustoms_2
{
    public class Group
    {
        public string String { get; set; }

        public List<string> PassengersStrings => String
            .Split(Environment.NewLine)
            .ToList()
            ;

        public int NumberOfDifferentYes => PassengersStrings
            .First()
            .Where(x => PassengersStrings.All(y => y.Contains(x)))
            .Count()
            ;
    }
}
