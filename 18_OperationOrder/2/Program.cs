using System;
using System.IO;
using System.Linq;
using _18_OperationOrder_2;

var inputFile = @".\input";

var sum = File
    .ReadAllLines(inputFile)
    .Select(x => new Formula { String = x })
    .Select(x => x.EvaluateValue())
    .Select(x => long.Parse(x))
    .Sum();

Console.WriteLine(sum);
