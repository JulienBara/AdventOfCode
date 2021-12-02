using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";
var preambuleSize = 25;

var numbers = File
    .ReadAllLines(inputFile)
    .Select(x => long.Parse(x))
    .ToList();

for (int i = preambuleSize; i < numbers.Count; i++)
{
    var isSum = false;
    for (int j = Math.Max(0, i - preambuleSize); j < i; j++)
    {
        for (int k = j + 1; k < i; k++)
        {
            if(numbers[j] + numbers[k] == numbers[i])
                isSum = true;
        }
    }
    if(! isSum)
        Console.WriteLine(numbers[i]);
}
