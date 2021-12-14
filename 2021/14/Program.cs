using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile);
var puzzle = input.Split(Environment.NewLine + Environment.NewLine)[0];
var dict = input
    .Split(Environment.NewLine + Environment.NewLine)
    [1]
    .Split(Environment.NewLine)
    .Select(x => x.Split(" -> "))
    .ToDictionary(
        x => x[0],
        x => x[1]
    );

for (int i = 0; i < 10; i++)
{
    var newPuzzle = puzzle[0].ToString();
    for (int j = 1; j < puzzle.Length; j++)
    {
        newPuzzle += dict[$"{puzzle[j - 1]}{puzzle[j]}"];
        newPuzzle += puzzle[j];
    }
    puzzle = newPuzzle;
}

var orderedItems = puzzle
    .GroupBy(x => x)
    .Select(x => x.Count())
    .OrderByDescending(x => x);

Console.WriteLine(orderedItems.First() - orderedItems.Last());

