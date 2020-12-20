using System;
using System.IO;
using System.Linq;
using _20_JurassicJigsaw_1;

var inputFile = @".\input";

var tiles = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => new Tile { String = x })
    .ToList();

var productCorner = tiles
    .Where(x => x.IsCorner(tiles))
    .Aggregate(
        (long)1, 
        (accu, tile) => accu *= long.Parse(tile.Id)
    );

Console.WriteLine(productCorner);
