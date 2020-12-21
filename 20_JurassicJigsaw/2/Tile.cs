using System;
using System.Collections.Generic;
using System.Linq;

namespace _20_JurassicJigsaw_2
{
    public class Tile
    {
        public string String { get; set; }

        public string Id => String
            .Split(Environment.NewLine)
            .First()
            .Skip("Tile ".Length)
            .SkipLast(1)
            .Aggregate("", (s, c) => s += c);

        public List<string> Square => String
            .Split(Environment.NewLine)
            .Skip(1)
            .ToList();

        public int CountInside => Square
            .Skip(1)
            .SkipLast(1)
            .Select(x => x.Skip(1).SkipLast(1))
            .Select(x => x.Where(y => y == '#').Count())
            .Aggregate(0, (accu, value) => accu += value);
    }
}