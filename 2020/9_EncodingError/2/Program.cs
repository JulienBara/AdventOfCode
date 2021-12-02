using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";
var invalidNumber = 258585477;

var numbers = File
    .ReadAllLines(inputFile)
    .Select(x => long.Parse(x))
    .ToList();

var queue = new Queue <long>();

for (int i = 0; i < numbers.Count; i++)
{
    queue.Enqueue(numbers[i]);
    while(queue.Sum() > invalidNumber)
        queue.Dequeue();
    if(queue.Sum() == invalidNumber)
        Console.WriteLine(queue.OrderBy(x => x).First() + queue.OrderBy(x => x).Last());
}
