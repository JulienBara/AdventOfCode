using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllLines(inputFile)
    .Select(x => x
        .Select(y => Int32.Parse(y.ToString()))
        .ToArray()
    )
    .ToArray();

var riskGrid = Enumerable.Range(0, input.Length)
    .Select(x => Enumerable.Range(0, input[0].Length)
        .Select(y => Int32.MaxValue)
        .ToArray()
    ).ToArray();

var processed = new HashSet<(int, int)>();
riskGrid[input.Length - 1][input[0].Length - 1] = input[input.Length - 1][input[0].Length - 1];

while (processed.Count < input.Length * input[0].Length)
{
    var (x, y) = itemToProcess();

    if (y - 1 >= 0)
        riskGrid[x][y - 1] = Math.Min(riskGrid[x][y - 1], riskGrid[x][y] + input[x][y - 1]);

    if (y + 1 < input[0].Length)
        riskGrid[x][y + 1] = Math.Min(riskGrid[x][y + 1], riskGrid[x][y] + input[x][y + 1]);

    if (x - 1 >= 0)
        riskGrid[x - 1][y] = Math.Min(riskGrid[x - 1][y], riskGrid[x][y] + input[x - 1][y]);

    if (x + 1 < input.Length)
        riskGrid[x + 1][y] = Math.Min(riskGrid[x + 1][y], riskGrid[x][y] + input[x + 1][y]);

    processed.Add((x, y));
}

Console.WriteLine(riskGrid[0][0] - input[0][0]);

(int, int) itemToProcess()
{
    var minValue = Int32.MaxValue;
    var minIndex = (0, 0);

    for (int x = 0; x < input.Length; x++)
    {
        for (int y = 0; y < input[0].Length; y++)
        {
            if (processed.Contains((x, y))) { continue; }
            if (riskGrid[x][y] >= minValue) { continue; }

            minValue = riskGrid[x][y];
            minIndex = (x, y);
        }
    }

    return minIndex;
}
