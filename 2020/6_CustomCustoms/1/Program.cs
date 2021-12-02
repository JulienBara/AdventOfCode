using System;
using System.IO;
using System.Linq;
using  _6_CustomCustoms_1;

var inputFile = @".\input";

var sumGroupNumberOfDifferentYes = File
    .ReadAllText(inputFile)
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(groupString => new Group(groupString))
    .Sum(group => group.NumberOfDifferentYes);

Console.WriteLine(sumGroupNumberOfDifferentYes);
