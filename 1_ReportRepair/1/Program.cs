using System.IO;
using System.Linq;

var inputFile = @".\input";
var sumToFind = 2020;

var numbers = File
    .ReadAllLines(inputFile)
    .Select(x => System.Int32.Parse(x));

var lowerNumbersStack = numbers
    .Where(x => x < sumToFind / 2)
    .OrderByDescending(x => x)
    .ToList();
var higherNumbersStack = numbers
    .Where(x => x > sumToFind / 2)
    .OrderBy(x => x)
    .ToList();

while(lowerNumbersStack.Count > 0 && higherNumbersStack.Count > 0)
{
    var lowerNumber = lowerNumbersStack.First();
    var higherNumber = higherNumbersStack.First();

    switch (lowerNumber + higherNumber)
    {
        case int sum when sum > sumToFind:
            lowerNumbersStack.RemoveAt(0);
            break;
        case int sum when sum < sumToFind:
            higherNumbersStack.RemoveAt(0);
            break;
        default:
            System.Console.WriteLine(lowerNumber * higherNumber);
            return;
    }
}
