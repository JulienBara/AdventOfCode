using System;
using System.IO;
using System.Linq;
using _19_MonsterMessages_2;

var inputFile = @".\input";

var input = File.ReadAllText(inputFile);
var rules = input
    .Split(Environment.NewLine + Environment.NewLine)
    [0]
    .Split(Environment.NewLine)
    .Select(x => new Rule { String = x })
    .ToDictionary(x => x.Id);

var messages = input
    .Split(Environment.NewLine + Environment.NewLine)
    [1]
    .Split(Environment.NewLine);

rules[0].GetRegexPattern(rules);
var matchFunc = rules[0].MatchesRegex;

var sum = messages
    .Select(x => matchFunc(x))
    .Select(x => x ? 1 : 0)
    .Sum();

Console.WriteLine(sum);
