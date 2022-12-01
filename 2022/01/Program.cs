using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");
var result = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => x.Split(Environment.NewLine))
    .Select(x => x.Select(y => Int32.Parse(y)))
    .Select(x => x.Sum())
    .OrderByDescending(x => x)
    .First();

System.Console.WriteLine(result);

