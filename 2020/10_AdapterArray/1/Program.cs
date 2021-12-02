using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var aggregateAdapters = File
    .ReadAllLines(inputFile)
    .Select(x => int.Parse(x))
    .OrderBy(x => x)
    .Aggregate(
        new { Previous = 0, Count1 = 0, Count3 = 0 },
        (accu, current) => new 
        { 
            Previous = current, 
            Count1 = accu.Count1 + (current - accu.Previous == 1 ? 1 : 0), 
            Count3 = accu.Count3 + (current - accu.Previous == 3 ? 1 : 0), 
        }); 

Console.WriteLine(aggregateAdapters.Count1 * (aggregateAdapters.Count3 + 1));
