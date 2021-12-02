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

var countTotal = tiles
    .Select(x => x.CountInside)
    .Aggregate(0, (accu, value) => accu += value);

var countSeaMonster = 15;

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(countTotal - i*countSeaMonster);
}

// Tested:
// 2153
// 2138
// 2123
// 2108
// 2093
// 2078
// 2063
// 2048
// 2033
// 2018