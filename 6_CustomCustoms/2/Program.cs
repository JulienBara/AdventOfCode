﻿using System;
using System.IO;
using System.Linq;
using _6_CustomCustoms_2;

var inputFile = @".\input";

var sumCountDifferentYes = File
    .ReadAllText(inputFile)
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(x => new Group {String = x})
    .Sum(x => x.NumberOfDifferentYes)
    ;

System.Console.WriteLine(sumCountDifferentYes);