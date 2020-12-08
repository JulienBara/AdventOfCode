using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var instructions = File
    .ReadAllLines(inputFile)
    .Select(x => new 
    {
        Line = x,
        Operation = x.Substring(0,3),
        Argument = new 
        {
            Sign = x[4],
            Value = int.Parse(x.Substring(5))
        }
    })
    .ToArray();

var nextInstructionIndex = 0;
var accumulator = 0;
var visitedIndexes = new bool[instructions.Length];

while (! visitedIndexes[nextInstructionIndex])
{
    visitedIndexes[nextInstructionIndex] = true;

    var instruction = instructions[nextInstructionIndex];
    switch (instruction.Operation)
    {
        case "acc" when instruction.Argument.Sign == '+':
            accumulator += instruction.Argument.Value;
            nextInstructionIndex++;
            break;
        case "acc" when instruction.Argument.Sign == '-':
            accumulator -= instruction.Argument.Value;
            nextInstructionIndex++;
            break;
        case "jmp" when instruction.Argument.Sign == '+':
            nextInstructionIndex += instruction.Argument.Value;
            break;
        case "jmp" when instruction.Argument.Sign == '-':
            nextInstructionIndex -= instruction.Argument.Value;
            break;
        case "nop":
            nextInstructionIndex++;
            break;
    }
}

Console.WriteLine(accumulator);
