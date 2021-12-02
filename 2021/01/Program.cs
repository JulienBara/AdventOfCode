using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var numbers = File
    .ReadAllLines(inputFile)
    .Select(x => System.Int32.Parse(x));

var increasesCount = 0;
int? previous = null;
var slidingWindow = new Queue<int>();

foreach (var number in numbers)
{
    slidingWindow.Enqueue(number);
    if (slidingWindow.Count < 3) { continue; }

    var sum = slidingWindow.Sum();
    if (previous < sum) { increasesCount++; }
    previous = sum;
    slidingWindow.Dequeue();
}

Console.WriteLine(increasesCount);
