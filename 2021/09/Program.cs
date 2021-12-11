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

var lowestPointsScore = 0;
for (int i = 0; i < rowsCount; i++)
{
    for (int j = 0; j < colsCount; j++)
    {
        if (isLowestPoint(i, j))
            lowestPointsScore += grid[i, j] + 1;
    }
}

Console.WriteLine(lowestPointsScore);

bool isLowestPoint(int i, int j)
{
    if (i > 0 && grid[i - 1, j] <= grid[i, j])
        return false;

    if (j > 0 && grid[i, j - 1] <= grid[i, j])
        return false;

    if (i < rowsCount - 1 && grid[i + 1, j] <= grid[i, j])
        return false;

    if (j < colsCount - 1 && grid[i, j + 1] <= grid[i, j])
        return false;

    return true;
}