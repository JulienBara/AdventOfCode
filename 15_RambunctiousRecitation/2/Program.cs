using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";
var stopTour = 30000000;

var startingNumbers = File
    .ReadAllText(inputFile)
    .Split(",")
    .Select(x => long.Parse(x));

var tour = 0;
var numbers = new Dictionary<long, long>(); // number, last tour
long previousNumber = 0;
bool previousNumberExisted = false;
long previousNumberPreviousTour = 0;

foreach (var startingNumber in startingNumbers)
{
    tour++;
    previousNumber = startingNumber;
    previousNumberExisted = numbers.ContainsKey(previousNumber);
    previousNumberPreviousTour = previousNumberExisted ? numbers[previousNumber] : 0;

    numbers[previousNumber] = tour;
}

while (tour < stopTour)
{
    long nextNumber;
    if(! previousNumberExisted){
        nextNumber = 0;
    }else{
        nextNumber = tour - previousNumberPreviousTour;
    }

    previousNumber = nextNumber;
    previousNumberExisted = numbers.ContainsKey(previousNumber);
    previousNumberPreviousTour = previousNumberExisted ? numbers[previousNumber] : 0;

    tour++;
    numbers[previousNumber] = tour;
}

Console.WriteLine(previousNumber);
