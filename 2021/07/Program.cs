using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var positions = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => Int32.Parse(x));

var min = Enumerable.Range(positions.Min(), positions.Max() + 1)
    .Select(point => positions
        .Select(position => Math.Abs(position - point))
        .Sum()
    )
    .Min();

Console.WriteLine(min);
