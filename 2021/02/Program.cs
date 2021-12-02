using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var position = File
    .ReadAllLines(inputFile)
    .Select(x => x.Split())
    .Select(x => new Command(x[0], Int32.Parse(x[1])))
    .Aggregate(
        new { Horizontal = 0, Depth = 0, Aim = 0 },
        (position, command) => command switch
        {
            Command { Direction: "forward" } => new { Horizontal = position.Horizontal + command.Unit, Depth = position.Depth + position.Aim * command.Unit, Aim = position.Aim },
            Command { Direction: "down" } => new { Horizontal = position.Horizontal, Depth = position.Depth, Aim = position.Aim + command.Unit },
            Command { Direction: "up" } => new { Horizontal = position.Horizontal, Depth = position.Depth, Aim = position.Aim - command.Unit }
        }
    );

System.Console.WriteLine(position.Horizontal * position.Depth);

public record Command(string Direction, int Unit);
