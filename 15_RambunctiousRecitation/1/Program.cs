using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";
var stopCount = 2020;

var startingNumbers = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => long.Parse(x));

var count = 0;
var numbers = new List<long>();

foreach (var startingNumber in startingNumbers)
{
    numbers.Add(startingNumber);
    count++;
}

while (count < stopCount)
{
    var number = numbers.Last();
    long nextNumber;
    if(numbers.Where(x => x == number).Count() == 1){
        nextNumber = 0;
    }else{
        nextNumber = numbers.Count() 
            - (numbers.LastIndexOf(number, numbers.Count() - 2) + 1); // last tour number = last index + 1
    }

    numbers.Add(nextNumber);
    count++;
}

Console.WriteLine(numbers.Last());
