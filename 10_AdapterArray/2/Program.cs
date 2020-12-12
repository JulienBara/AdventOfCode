using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var aggregateAdaptersDiffs = File
    .ReadAllLines(inputFile)
    .Select(x => int.Parse(x))
    .OrderBy(x => x)
    .Aggregate(
        new { Previous = 0, Diffs = new List<int>() },
        (accu, current) => new 
        { 
            Previous = current, 
            Diffs = accu.Diffs.Append(current - accu.Previous).ToList()
        })
    .Diffs; 



var combo2 = 0;
var combo3 = 0;
var combo4 = 0;

for (int i = 0; i < aggregateAdaptersDiffs.Count; i++)
{
    if(
        i+3 < aggregateAdaptersDiffs.Count
        && aggregateAdaptersDiffs[i] == 1
        && aggregateAdaptersDiffs[i+1] == 1
        && aggregateAdaptersDiffs[i+2] == 1
        && aggregateAdaptersDiffs[i+3] == 1
    )
    {
        combo4++;
        i += 3;
        continue;
    }
    if(
        i+2 < aggregateAdaptersDiffs.Count
        && aggregateAdaptersDiffs[i] == 1
        && aggregateAdaptersDiffs[i+1] == 1
        && aggregateAdaptersDiffs[i+2] == 1
    )
    {
        combo3++;
        i += 2;
        continue;
    }
    if(
        i+1 < aggregateAdaptersDiffs.Count
        && aggregateAdaptersDiffs[i] == 1
        && aggregateAdaptersDiffs[i+1] == 1
    )
    {
        combo2++;
        i += 1;
        continue;
    }
}

Console.WriteLine(Math.Pow(2,combo2)*Math.Pow(4,combo3)*Math.Pow(7,combo4));
