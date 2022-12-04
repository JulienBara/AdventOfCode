using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Select(x => x
        .Split(",")
        .Select(y => y
            .Split("-")
            .Select(z => Int32.Parse(z))
            .ToList()
        )
        .Select(y => Enumerable.Range(y[0], y[1] - y[0] + 1).ToList())
        .ToList()
    )
    .Where(x => x[0].Count() == x[0].Union(x[1]).Count()
        || x[1].Count() == x[1].Union(x[0]).Count())
    .Count();

System.Console.WriteLine(result1);
