using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result = File
    .ReadAllLines(inputFile)
    .Select(x => x
        .Split(" | ")
        [1]
        .Split(" ")
        .Where(x =>
            x.Length == 2 // 1
            || x.Length == 4 // 4
            || x.Length == 3 // 7
            || x.Length == 7 // 8
        )
        .Count()
    ).Sum();

Console.WriteLine(result);
