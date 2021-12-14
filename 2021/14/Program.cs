using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile);
var firstLine = input
    .Split(Environment.NewLine + Environment.NewLine)[0];
var puzzleDuetsCounts = firstLine
    .SelectMany(x => new List<char>() { x, x })
    .Skip(1)
    .SkipLast(1)
    .Chunk(2)
    .GroupBy(x => $"{x[0]}{x[1]}")
    .ToDictionary(
        x => x.Key,
        x => (long)x.Count()
    );
var dict = input
    .Split(Environment.NewLine + Environment.NewLine)
    [1]
    .Split(Environment.NewLine)
    .Select(x => x.Split(" -> "))
    .ToDictionary(
        x => x[0],
        x => new List<string>() { $"{x[0][0]}{x[1]}", $"{x[1]}{x[0][1]}" }
    );

for (int i = 0; i < 40; i++)
{
    var newPuzzleDuetsCounts = new Dictionary<string, long>();

    foreach (var duetCount in puzzleDuetsCounts)
    {
        var nextDuets = dict[duetCount.Key];
        if (!newPuzzleDuetsCounts.ContainsKey(nextDuets[0]))
            newPuzzleDuetsCounts[nextDuets[0]] = 0;
        if (!newPuzzleDuetsCounts.ContainsKey(nextDuets[1]))
            newPuzzleDuetsCounts[nextDuets[1]] = 0;

        newPuzzleDuetsCounts[nextDuets[0]] += duetCount.Value;
        newPuzzleDuetsCounts[nextDuets[1]] += duetCount.Value;
    }
    puzzleDuetsCounts = newPuzzleDuetsCounts;
}

var dictCounts = new Dictionary<char, long>();
foreach (var duet in puzzleDuetsCounts)
{
    if (!dictCounts.ContainsKey(duet.Key[0]))
        dictCounts[duet.Key[0]] = 0;
    if (!dictCounts.ContainsKey(duet.Key[1]))
        dictCounts[duet.Key[1]] = 0;

    dictCounts[duet.Key[0]] += duet.Value;
    dictCounts[duet.Key[1]] += duet.Value;
}

dictCounts[firstLine.First()]++;
dictCounts[firstLine.Last()]++;

foreach (var count in dictCounts)
{
    dictCounts[count.Key] /= 2;
}

var orderedItems = dictCounts
    .OrderByDescending(x => x.Value);

Console.WriteLine(orderedItems.First().Value - orderedItems.Last().Value);

