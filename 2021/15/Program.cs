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

var biggerCave = new int[input.Length * 5][];

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        for (int x = 0; x < input.Length; x++)
        {
            biggerCave[i * input.Length + x] = biggerCave[i * input.Length + x] ?? new int[input[0].Length * 5];

            for (int y = 0; y < input[0].Length; y++)
            {
                biggerCave[i * input.Length + x][j * input[0].Length + y] = (input[x][y] + i + j);
                if (biggerCave[i * input.Length + x][j * input[0].Length + y] >= 10)
                    biggerCave[i * input.Length + x][j * input[0].Length + y] -= 9;
            }
        }
    }
}

var riskGrid = Enumerable.Range(0, biggerCave.Length)
    .Select(x => Enumerable.Range(0, biggerCave[0].Length)
        .Select(y => Int32.MaxValue)
        .ToArray()
    ).ToArray();

var processed = new HashSet<(int, int)>();
var toProcess = new HashSet<(int, int)>();
for (int x = 0; x < riskGrid.Length; x++)
{
    for (int y = 0; y < riskGrid.Length; y++)
    {
        toProcess.Add((x, y));
    }
}

riskGrid[biggerCave.Length - 1][biggerCave[0].Length - 1] = biggerCave[biggerCave.Length - 1][biggerCave[0].Length - 1];

while (processed.Count < biggerCave.Length * biggerCave[0].Length)
{
    var (x, y) = itemToProcess();

    if (y - 1 >= 0)
        riskGrid[x][y - 1] = Math.Min(riskGrid[x][y - 1], riskGrid[x][y] + biggerCave[x][y - 1]);

    if (y + 1 < biggerCave[0].Length)
        riskGrid[x][y + 1] = Math.Min(riskGrid[x][y + 1], riskGrid[x][y] + biggerCave[x][y + 1]);

    if (x - 1 >= 0)
        riskGrid[x - 1][y] = Math.Min(riskGrid[x - 1][y], riskGrid[x][y] + biggerCave[x - 1][y]);

    if (x + 1 < biggerCave.Length)
        riskGrid[x + 1][y] = Math.Min(riskGrid[x + 1][y], riskGrid[x][y] + biggerCave[x + 1][y]);

    processed.Add((x, y));
    toProcess.Remove((x, y));
    Console.Write("\rProgress: {0}%   ", 100 * processed.Count / (500 * 500));
}

Console.WriteLine(riskGrid[0][0] - biggerCave[0][0]);

(int, int) itemToProcess()
{
    var minValue = Int32.MaxValue;
    var minIndex = (0, 0);

    foreach (var (x, y) in toProcess)
    {
        if (riskGrid[x][y] >= minValue) { continue; }

        minValue = riskGrid[x][y];
        minIndex = (x, y);
    }

    return minIndex;
}
