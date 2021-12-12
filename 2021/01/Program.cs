using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");


// 1

var result1 = File
    .ReadAllLines(inputFile)
    .Select(x => System.Int32.Parse(x))
    .SelectMany(x => new List<int> { x, x })
    .Skip(1)
    .SkipLast(1)
    .Chunk(2)
    .Aggregate(0, (accu, value) => accu += value[0] < value[1] ? 1 : 0);

System.Console.WriteLine(result1);

// 2

{
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
}
