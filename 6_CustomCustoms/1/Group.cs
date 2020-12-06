using System;
using System.Linq;

namespace _6_CustomCustoms_1
{
    public class Group
    {
        public string String { get; set; }

        public int NumberOfDifferentYes => String
            .ToCharArray()
            .Where(x => !string.IsNullOrWhiteSpace(x.ToString()))
            .Distinct()
            .Count()
            ;
    }
}
