using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllText(inputFile)
    .Select((c, i) => (c, i: (i + 1).ToString()))
    .Aggregate(
        "",
        (acc, x) => Int32.TryParse(acc, out _)
            ? acc
            : (acc = String.Join("", acc.Append(x.c).TakeLast(4))).Distinct().Count() < 4
                ? acc
                : x.i
    );

System.Console.WriteLine(result1);

var result2 = File
    .ReadAllText(inputFile)
    .Select((c, i) => (c, i: (i + 1).ToString()))
    .Aggregate(
        "",
        (acc, x) => Int32.TryParse(acc, out _)
            ? acc
            : (acc = String.Join("", acc.Append(x.c).TakeLast(14))).Distinct().Count() < 14
                ? acc
                : x.i
    );

System.Console.WriteLine(result2);