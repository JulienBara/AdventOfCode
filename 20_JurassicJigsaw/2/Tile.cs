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

        // mutation
        public void Rotate(int degrees) // horaire
        {
            for (int i = 0; i < degrees; i+=90)
            {
                var lines = new List<string>();
                for (int j = 0; j < Square.Count; j++)
                {
                    var line = "";
                    for (int k = 0; k < Square.Count; k++)
                    {
                        line += Square[Square.Count-k-1][j];
                    }
                    lines.Add(line);
                }
                String = "Tile " + Id + ":" + Environment.NewLine
                + string.Join(Environment.NewLine, lines);
            }  
        }
    }
}