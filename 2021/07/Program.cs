using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var positions = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => Int32.Parse(x));

var distancesCosts = Enumerable.Range(0, positions.Max() - positions.Min() + 1)
    .Select(distance => Enumerable.Range(0, distance + 1).Sum())
    .ToArray();

var min = Enumerable.Range(positions.Min(), positions.Max() + 1)
    .Select(point => positions
        .Select(position => distancesCosts[Math.Abs(position - point)])
        .Sum()
    )
    .Min();

Console.WriteLine(min);
