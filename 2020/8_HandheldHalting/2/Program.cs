using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var lines = File
    .ReadAllLines(inputFile)
    .ToList();

for (int i = 0; i < lines.Count; i++)
{
    var copiedLines = new List<string>(lines);
    if(copiedLines[i].Substring(0,3) == "acc")
        continue;
    if(copiedLines[i].Substring(0,3) == "nop")
        copiedLines[i] = copiedLines[i].Replace("nop", "jmp");
    else
        copiedLines[i] = copiedLines[i].Replace("jmp", "nop");

    var instructions = copiedLines
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

    while (nextInstructionIndex != instructions.Count() && ! visitedIndexes[nextInstructionIndex])
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

    if(nextInstructionIndex == lines.Count)
        Console.WriteLine(accumulator);
}
