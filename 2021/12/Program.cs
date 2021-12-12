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

var score = countPaths("start", new List<string>(), null);

Console.WriteLine(score);

int countPaths(string currentCave, List<string> visitedSmallCaves, string smallCaveVisitedTwice)
{
    if (currentCave == "end") { return 1; }
    if (smallCaveVisitedTwice == "start") { return 0; } // can't visit start twice
    if (smallCaveVisitedTwice == currentCave) { return 0; } // can't visit a small cave three times
    // can't visit a small cave twice of already one small cave has been visited twice
    if (smallCaveVisitedTwice != null && visitedSmallCaves.Contains(currentCave)) { return 0; }

    if (visitedSmallCaves.Contains(currentCave))
        smallCaveVisitedTwice = currentCave;

    var count = 0;
    foreach (var nextCave in graph[currentCave])
    {
        count += countPaths(
            nextCave,
            currentCave.All(x => Char.IsLower(x)) ? visitedSmallCaves.Prepend(currentCave).ToList() : visitedSmallCaves,
            smallCaveVisitedTwice
        );
    }
    return count;
}
