using System;
using System.IO;
using System.Linq;
using _20_JurassicJigsaw_2;

var inputFile = @".\input";

var tiles = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => new Tile { String = x })
    .ToList();

var matrix = new char[
    (int)Math.Sqrt(tiles.Count())*(tiles[0].Square[0].Count()-2), 
    (int)Math.Sqrt(tiles.Count())*(tiles[0].Square[0].Count()-2)
];

var currentTile = tiles
    .First(x => x.IsCorner(tiles));

var filteredTiles = tiles.Where(x => x.Id != currentTile.Id);
var matchingBorders = currentTile
    .Lines
    .Where(x => filteredTiles.Any(y => y.AllLines.Contains(x)))
    .Select(x => currentTile.Lines.IndexOf(x))
    .ToList();

if(matchingBorders[0] == 0 && matchingBorders[1] == 1) // case of input test
{
    currentTile.Rotate(90);
}
if(matchingBorders[0] == 1 && matchingBorders[1] == 2) // case of input chall
{
    currentTile.Rotate(0);
}

for (int i = 1; i < currentTile.Square.Count() - 1; i++)
{
    for (int j = 1; j < currentTile.Square.Count() - 1; j++)
    {
        matrix[i,j] = currentTile.Square[i][j];
    }
}

// Console.WriteLine("");
