using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File
    .ReadAllLines(inputFile);

var rowsCount = input.Length;
var colsCount = input[0].Length;

var grid = new int[rowsCount, colsCount];
for (int i = 0; i < rowsCount; i++)
{
    for (int j = 0; j < colsCount; j++)
    {
        grid[i, j] = Int32.Parse(input[i][j].ToString());
    }
}

var bassinsSizes = new List<int>();
for (int i = 0; i < rowsCount; i++)
{
    for (int j = 0; j < colsCount; j++)
    {
        if (grid[i, j] == 9) continue;

        var bassinSize = computeBassinSize(i, j);
        bassinsSizes.Add(bassinSize);
    }
}

var score = bassinsSizes
    .OrderByDescending(x => x)
    .Take(3)
    .Aggregate(
        1,
        (accu, value) => accu *= value
    );

Console.WriteLine(score);

int computeBassinSize(int i, int j)
{
    if (i < 0) return 0;
    if (j < 0) return 0;
    if (i > rowsCount - 1) return 0;
    if (j > colsCount - 1) return 0;
    if (grid[i, j] == 9) return 0;

    grid[i, j] = 9;

    return 1
    + computeBassinSize(i - 1, j)
    + computeBassinSize(i + 1, j)
    + computeBassinSize(i, j - 1)
    + computeBassinSize(i, j + 1);
}