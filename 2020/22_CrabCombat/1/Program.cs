using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;

var inputFile = @".\input";

var inputs = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Select(x => x.Split(Environment.NewLine).Skip(1).Select(y => long.Parse(y)).ToList())
    .Select(x => new Queue<long>(x))
    .ToList();

var queuePlayer1 = inputs[0];
var queuePlayer2 = inputs[1];

while(queuePlayer1.Count > 0 && queuePlayer2.Count > 0)
{
    var number1 = queuePlayer1.Dequeue();
    var number2 = queuePlayer2.Dequeue();
    if(number1 > number2)
    {
        queuePlayer1.Enqueue(number1);
        queuePlayer1.Enqueue(number2);
    } 
    else 
    {
        queuePlayer2.Enqueue(number2);
        queuePlayer2.Enqueue(number1);
    }
}

var winingQueue = queuePlayer2.Count == 0 ? queuePlayer1 : queuePlayer2;

long sum = 0;
var i = winingQueue.Count;
foreach (var item in winingQueue)
{
    sum += item * i;
    i--;
}

Console.WriteLine(sum);