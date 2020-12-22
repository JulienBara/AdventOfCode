using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using _22_CrabCombat_2;

var inputFile = @".\input";

var inputs = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => x.Split(Environment.NewLine).Skip(1).Select(y => long.Parse(y)).ToList())
    .Select(x => new Queue<long>(x))
    .ToList();

var queuePlayer1 = inputs[0];
var queuePlayer2 = inputs[1];

var game = new Game(queuePlayer1, queuePlayer2);
var winner = game.ReturnWinner();

var winingQueue = winner == 1 ? queuePlayer1 : queuePlayer2;

long sum = 0;
var i = winingQueue.Count;
foreach (var item in winingQueue)
{
    sum += item * i;
    i--;
}

Console.WriteLine(sum);