using System;
using System.IO;
using System.Linq;
using _6_CustomCustoms_2;

var inputFile = @".\input";

var sumNumberOfDifferentYesPerGroup = File
    .ReadAllText(inputFile)
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(groupString => new Group(groupString))
    .Sum(x => x.NumberOfDifferentYes);

System.Console.WriteLine(sumNumberOfDifferentYesPerGroup);
