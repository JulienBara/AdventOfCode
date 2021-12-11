using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File
    .ReadAllLines(inputFile);

var size = input.Length;

var grid = new int[size, size];

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        grid[i, j] = Int32.Parse(input[i][j].ToString());
    }
}

var flashesCount = 0;
var greyPositions = new Queue<(int, int)>();
var step = 0;

while (!areOnly0(grid))
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            grid[i, j]++;
            if (grid[i, j] > 9)
                greyPositions.Enqueue((i, j));
        }
    }

    while (greyPositions.Count > 0)
    {
        var (i, j) = greyPositions.Dequeue();

        if (grid[i, j] == 0) { continue; }

        grid[i, j]++;
        if (grid[i, j] <= 9) { continue; }

        flashesCount++;
        grid[i, j] = 0;

        for (int x = Math.Max(0, i - 1); x <= Math.Min(size - 1, i + 1); x++)
        {
            for (int y = Math.Max(0, j - 1); y <= Math.Min(size - 1, j + 1); y++)
            {
                greyPositions.Enqueue((x, y));
            }
        }
    }

    step++;
}

Console.WriteLine(step);

bool areOnly0(int[,] grid)
{
    var enumerator = grid.GetEnumerator();
    while (enumerator.MoveNext())
    {
        if ((int)enumerator.Current != 0)
            return false;
    };
    return true;
}
