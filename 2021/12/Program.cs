using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var graph = File
    .ReadAllLines(inputFile)
    .Select(x => x.Split("-"))
    .Select(x => new { Start = x[0], End = x[1] })
    .Aggregate(
        new Dictionary<string, List<string>>(),
        (accu, segment) =>
        {
            if (!accu.ContainsKey(segment.Start))
                accu[segment.Start] = new List<string>();
            if (!accu.ContainsKey(segment.End))
                accu[segment.End] = new List<string>();

            accu[segment.Start].Add(segment.End);
            accu[segment.End].Add(segment.Start);

            return accu;
        }
    );

var score = countPaths("start", new List<string>());

Console.WriteLine(score);

int countPaths(string currentCave, List<string> visitedSmallCaves)
{
    if (currentCave == "end") { return 1; }
    if (graph[currentCave].All(x => visitedSmallCaves.Contains(x))) { return 0; }

    var count = 0;
    foreach (var nextCave in graph[currentCave].Where(x => !visitedSmallCaves.Contains(x)))
    {
        count += countPaths(
            nextCave,
            currentCave.All(x => Char.IsLower(x)) ? visitedSmallCaves.Prepend(currentCave).ToList() : visitedSmallCaves
        );
    }
    return count;
}
