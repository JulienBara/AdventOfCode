using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var numbers =  File
    .ReadAllText(inputFile)
    .Select(x => long.Parse(x.ToString()))
    .ToList();

for (int i = numbers.Count + 1; i <= 1000000; i++)
{
    numbers.Add(i);
}

var turnCount = 10000000;

for (int i = 0; i < turnCount; i++)
{
    Console.WriteLine(i);
    var first = numbers[0];
    var pickUps = numbers.GetRange(1, 3);

    numbers.RemoveRange(0, 4); // pop top

    var destination = first;
    while(! numbers.Contains(destination))
    {
        destination--;
        if(numbers.All(x => x > destination))
        {
            destination = numbers.Max();
        }
    }

    numbers.InsertRange(numbers.IndexOf(destination)+1, pickUps);
    numbers.Insert(numbers.Count(), first);
}

// rearrange to have correct final order
var indexOfOne = numbers.IndexOf(1);
var poppedNumbers = numbers.GetRange(0, indexOfOne);
numbers.RemoveRange(0, indexOfOne);
numbers.InsertRange(numbers.Count, poppedNumbers);

// remove one
numbers.Remove(1);

Console.WriteLine(numbers[0] * numbers[1]);
