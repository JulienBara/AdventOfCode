using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var instructions = File
    .ReadAllLines(inputFile)
    .Select(x => new 
    {
        Action = x.Substring(0,1),
        Value = int.Parse(x.Substring(1)),
    })
    .ToList();

var e = 0;
var n = 0;
var face = "E";
var rCardinalOrder = new List<string>{"N", "E", "S", "W"};
var lCardinalOrder = new List<string>{"N", "W", "S", "E"};

foreach (var instruction in instructions)
{
    switch (instruction.Action)
    {
        case "N":
            n += instruction.Value;
            break;
        case "S":
            n -= instruction.Value;
            break;
        case "E":
            e += instruction.Value;
            break;
        case "W":
            e -= instruction.Value;
            break;
        case "F":
            switch (face)
            {
                case "N":
                    n += instruction.Value;
                    break;
                case "S":
                    n -= instruction.Value;
                    break;
                case "E":
                    e += instruction.Value;
                    break;
                case "W":
                    e -= instruction.Value;
                    break;
            }
            break;
        case "R":
            face = rCardinalOrder[(rCardinalOrder.IndexOf(face) + instruction.Value / 90) % 4];
            break;
        case "L":
            face = lCardinalOrder[(lCardinalOrder.IndexOf(face) + instruction.Value / 90) % 4];
            break;
    }
}

System.Console.WriteLine(Math.Abs(n) + Math.Abs(e));