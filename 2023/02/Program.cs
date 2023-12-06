using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Select(line => new {
        Game = line.Split(": ")[0].Split(" ")[1],
        Sets = line.Split(": ")[1].Split("; ").Select(set => new {
            Red =  Regex.Match(set, @"(?<red>\d+) red").Groups["red"].Value,
            Green = Regex.Match(set, @"(?<green>\d+) green").Groups["green"].Value,
            Blue = Regex.Match(set, @"(?<blue>\d+) blue").Groups["blue"].Value
        })
    })
    .Select(game => new {
        Game = Int32.Parse(game.Game),
        Sets = game.Sets.Select(set => new {
            Red = Int32.TryParse(set.Red, out _) ? Int32.Parse(set.Red) : 0,
            Green = Int32.TryParse(set.Green, out _) ? Int32.Parse(set.Green) : 0,
            Blue = Int32.TryParse(set.Blue, out _) ? Int32.Parse(set.Blue) : 0,
        })
    })
    .Where(game => game.Sets.All(set => set.Red <= 12 && set.Green <= 13 && set.Blue <= 14))
    .Select(game => game.Game)
    .Sum()
    ;

System.Console.WriteLine(result1);
