using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Aggregate(new
    {
        Stacks = new List<Stack<char>>(),
        IsCommand = false
    },
    (acc, line) =>
    {
        if (line.Length >= 2 && line[1] == '1') // skip stack naming line
        {
            return acc;
        }
        if (line == "")
        {
            return new
            {
                // create stack from stack, reverses stack
                Stacks = acc.Stacks.Select(x => new Stack<char>(x)).ToList(),
                IsCommand = true
            };
        }
        if (!acc.IsCommand)
        {
            foreach (var (c, i) in line.Chunk(4).Select((x, i) => (x.ToList()[1], i)))
            {
                if (acc.Stacks.Count() < i + 1) { acc.Stacks.Add(new Stack<char>()); }
                if (c == ' ') { continue; }

                acc.Stacks[i].Push(c);
            }
            return acc;
        }
        else // acc.IsCommand
        {
            var reg = new Regex(@"move (?<moveCount>\d+?) from (?<fromStackId>\d+?) to (?<toStackId>\d+?)");
            var match = reg.Match(line);
            var moveCount = Int32.Parse(match.Groups["moveCount"].Value);
            var fromStackId = Int32.Parse(match.Groups["fromStackId"].Value);
            var toStackId = Int32.Parse(match.Groups["toStackId"].Value);

            for (int i = 0; i < moveCount; i++)
            {
                acc.Stacks[toStackId - 1].Push(acc.Stacks[fromStackId - 1].Pop());
            }
            return acc;
        }
    })
    .Stacks
    .Select(x => x.Pop());

System.Console.WriteLine(String.Join("", result1));

var result2 = File
    .ReadAllLines(inputFile)
    .Aggregate(new
    {
        Stacks = new List<Stack<char>>(),
        IsCommand = false
    },
    (acc, line) =>
    {
        if (line.Length >= 2 && line[1] == '1') // skip stack naming line
        {
            return acc;
        }
        if (line == "")
        {
            return new
            {
                // create stack from stack, reverses stack
                Stacks = acc.Stacks.Select(x => new Stack<char>(x)).ToList(),
                IsCommand = true
            };
        }
        if (!acc.IsCommand)
        {
            foreach (var (c, i) in line.Chunk(4).Select((x, i) => (x.ToList()[1], i)))
            {
                if (acc.Stacks.Count() < i + 1) { acc.Stacks.Add(new Stack<char>()); }
                if (c == ' ') { continue; }

                acc.Stacks[i].Push(c);
            }
            return acc;
        }
        else // acc.IsCommand
        {
            var reg = new Regex(@"move (?<moveCount>\d+?) from (?<fromStackId>\d+?) to (?<toStackId>\d+?)");
            var match = reg.Match(line);
            var moveCount = Int32.Parse(match.Groups["moveCount"].Value);
            var fromStackId = Int32.Parse(match.Groups["fromStackId"].Value);
            var toStackId = Int32.Parse(match.Groups["toStackId"].Value);

            var stack = new Stack<char>();
            for (int i = 0; i < moveCount; i++)
            {
                stack.Push(acc.Stacks[fromStackId - 1].Pop());
            }
            for (int i = 0; i < moveCount; i++)
            {
                acc.Stacks[toStackId - 1].Push(stack.Pop());
            }

            return acc;
        }
    })
    .Stacks
    .Select(x => x.Pop());

System.Console.WriteLine(String.Join("", result2));