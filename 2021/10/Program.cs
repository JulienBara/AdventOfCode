using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

var inputFile = Path.Combine(".", "input");

var openingClosingChunks = new Dictionary<char, char>
{
    ['('] = ')',
    ['['] = ']',
    ['{'] = '}',
    ['<'] = '>'
};

var chunkScores = new Dictionary<char, int>
{
    [')'] = 1,
    [']'] = 2,
    ['}'] = 3,
    ['>'] = 4
};

var score = File
    .ReadAllLines(inputFile)
    .Select(line =>
    {
        var stack = new Stack<char>();
        foreach (var c in line)
        {
            if (openingClosingChunks.ContainsKey(c))
            {
                stack.Push(c);
                continue;
            }

            var topChar = stack.Pop();
            if (openingClosingChunks[topChar] != c)
                return null;
        }

        return stack;
    })
    .Where(x => x != null)
    .Select(x => x
        .Aggregate(
            (long)0,
            (accu, c) => accu = accu * 5 + chunkScores[openingClosingChunks[c]]
        )
    )
    .Median();

Console.WriteLine(score);
