using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;

var inputFile = Path.Combine(".", "input");

var matrix = File
    .ReadAllLines(inputFile)
    .Select(x => x
        .Select(y => Int32.Parse(y.ToString()))
        .ToArray()
    )
    .ToArray();

var visibilityMatrix = Enumerable
    .Range(0, matrix.Count())
    .Select(x => Enumerable
        .Range(0, matrix[0].Count())
        .Select(y => false)
        .ToArray()
    )
    .ToArray();

List<int> maxes;

// top
maxes = Enumerable.Range(0, matrix.Count()).Select(x => -1).ToList();

for (int i = 0; i < matrix.Count(); i++)
{

    for (int j = 0; j < matrix[0].Count(); j++)
    {
        if (maxes[j] < matrix[i][j])
        {
            maxes[j] = matrix[i][j];
            visibilityMatrix[i][j] = true;
        }
    }
}

// bottom
maxes = Enumerable.Range(0, matrix.Count()).Select(x => -1).ToList();

for (int i = matrix.Count() - 1; i >= 0; i--)
{
    for (int j = 0; j < matrix[0].Count(); j++)
    {
        if (maxes[j] < matrix[i][j])
        {
            maxes[j] = matrix[i][j];
            visibilityMatrix[i][j] = true;
        }
    }
}

// left
maxes = Enumerable.Range(0, matrix.Count()).Select(x => -1).ToList();

for (int j = 0; j < matrix[0].Count(); j++)
{
    for (int i = 0; i < matrix.Count(); i++)
    {
        if (maxes[i] < matrix[i][j])
        {
            maxes[i] = matrix[i][j];
            visibilityMatrix[i][j] = true;
        }
    }
}

// right
maxes = Enumerable.Range(0, matrix.Count()).Select(x => -1).ToList();

for (int j = matrix.Count() - 1; j >= 0; j--)
{
    for (int i = 0; i < matrix[0].Count(); i++)
    {
        if (maxes[i] < matrix[i][j])
        {
            maxes[i] = matrix[i][j];
            visibilityMatrix[i][j] = true;
        }
    }
}

var result1 = visibilityMatrix
    .SelectMany(x => x)
    .Where(x => x)
    .Count();

System.Console.WriteLine(result1);
