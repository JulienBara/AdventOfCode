using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var fishCountPerAge = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => Int32.Parse(x))
    .GroupBy(x => x)
    .ToDictionary(x => x.Key, x => (long)x.Count());

for (int i = 0; i < 256; i++)
{
    fishCountPerAge = Enumerable.Range(0, 9)
        .ToDictionary(
            x => x,
            x =>
            {
                if (x == 8) { return fishCountPerAge.ContainsKey(0) ? fishCountPerAge[0] : 0; }
                if (x == 6)
                {
                    return (fishCountPerAge.ContainsKey(0) ? fishCountPerAge[0] : 0)
                    + (fishCountPerAge.ContainsKey(7) ? fishCountPerAge[7] : 0);
                }

                return fishCountPerAge.ContainsKey(x + 1) ? fishCountPerAge[x + 1] : 0;
            }
        );
}

Console.WriteLine(fishCountPerAge.Values.Sum());
