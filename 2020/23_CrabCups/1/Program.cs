using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var numbers =  File
    .ReadAllText(inputFile)
    .Select(x => int.Parse(x.ToString()))
    .ToList();

var turnCount = 100;

for (int i = 0; i < turnCount; i++)
{
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

Console.WriteLine(numbers.Aggregate("", (accu, value) => accu += value));
