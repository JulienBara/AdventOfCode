using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var fishes = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => Int32.Parse(x))
    .ToList();

for (int i = 0; i < 80; i++)
{
    var nextFishes = new List<int>();
    foreach (var fish in fishes)
    {
        if (fish == 0)
        {
            nextFishes.Add(8);
            nextFishes.Add(6);
            continue;
        }

        nextFishes.Add(fish - 1);
    }
    fishes = nextFishes;
}

Console.WriteLine(fishes.Count);
