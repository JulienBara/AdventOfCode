using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    [')'] = 3,
    [']'] = 57,
    ['}'] = 1197,
    ['>'] = 25137
};

var score = File
    .ReadAllLines(inputFile)
    .Aggregate(
        0,
        (accu, line) =>
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
                    return accu + chunkScores[c];
            }

            return accu;
        });

Console.WriteLine(score);
