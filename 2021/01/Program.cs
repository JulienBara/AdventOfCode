using System.IO;
using System.Linq;

var inputFile = @".\input";

var numbers = File
    .ReadAllLines(inputFile)
    .Select(x => System.Int32.Parse(x));

var increasesCount = 0;
int? previous = null;

foreach (var number in numbers)
{
    if (previous < number) { increasesCount++; }
    previous = number;
}

System.Console.WriteLine(increasesCount);
