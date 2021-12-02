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

var shipE = 0;
var shipN = 0;
var waypointE = 10;
var waypointN = 1;

foreach (var instruction in instructions)
{
    switch (instruction.Action)
    {
        case "N":
            waypointN += instruction.Value;
            break;
        case "S":
            waypointN -= instruction.Value;
            break;
        case "E":
            waypointE += instruction.Value;
            break;
        case "W":
            waypointE -= instruction.Value;
            break;
        case "F":
            shipN += instruction.Value * waypointN;
            shipE += instruction.Value * waypointE;
            break;
        case "R":
            switch (instruction.Value)
            {
                case 90:
                    {
                        var tempWaypointE = waypointE;
                        waypointE = waypointN;
                        waypointN = -tempWaypointE;
                    }
                    break;
                case 180:
                    waypointN *= -1;
                    waypointE *= -1;
                    break;
                case 270:
                    {
                        var tempWaypointE = waypointE;
                        waypointE = -waypointN;
                        waypointN = +tempWaypointE;
                    }
                    break;
                default:
                    throw new Exception($"Incorrect value {instruction.Value}");
            };
            break;
        case "L":
            switch (instruction.Value)
            {
                case 90:
                    {
                        var tempWaypointE = waypointE;
                        waypointE = -waypointN;
                        waypointN = tempWaypointE;
                    }
                    break;
                case 180:
                    waypointN *= -1;
                    waypointE *= -1;
                    break;
                case 270:
                    {
                        var tempWaypointE = waypointE;
                        waypointE = waypointN;
                        waypointN = -tempWaypointE;
                    }
                    break;
                default:
                    throw new Exception($"Incorrect value {instruction.Value}");
            };
            break;
    }
}

System.Console.WriteLine(Math.Abs(shipN) + Math.Abs(shipE));