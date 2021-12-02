using System;
using System.Collections.Generic;
using System.Linq;

namespace _20_JurassicJigsaw_1
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

        public string NorthLine => Square.First();
        public string SouthLine => Square
            .Last()
            .Reverse()
            .Aggregate("", (s, c) => s += c);
        public string WestLine => Square
            .Select(x => x.First())
            .Reverse()
            .Aggregate("", (s, c) => s += c);         
        public string EastLine => Square
            .Select(x => x.Last())
            .Aggregate("", (s, c) => s += c);

        
        public List<string> Lines => new List<string>
            {
                NorthLine,
                EastLine,
                SouthLine,
                WestLine
            };

        public List<string> ReversedLines => Lines
            .Select(x => x.Reverse().Aggregate("", (s, c) => s += c))
            .ToList();

        public List<string> AllLines => Lines
            .Concat(ReversedLines)
            .ToList();

        public bool IsCorner(List<Tile> tiles)
        {
            var filteredTiles = tiles.Where(x => x.Id != Id);
            var countMatchingBorders = Lines
                .Where(line => filteredTiles
                    .Any(filteredTile => filteredTile.AllLines.Contains(line))
                )
                .Count();
            return countMatchingBorders == 2;
        }
    }
}