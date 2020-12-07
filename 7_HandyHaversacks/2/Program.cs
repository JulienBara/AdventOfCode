using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using  _7_HandyHaversacks_2;

var inputFile = @".\input";

var bags = File
    .ReadAllLines(inputFile)
    .Select(x => new Bag(x))
    .ToDictionary(x => x.Name);

var greyBags = new List<string>();
var count = 0;

var startBag = "shiny gold";
greyBags.Add(startBag);

while(greyBags.Count > 0)
{
    var greyBag = greyBags.First();
    greyBags.Remove(greyBag);
    count++;
    foreach (var targetBag in bags[greyBag].Targets)
    {
        for (int i = 0; i < targetBag.Item2; i++)
        {
            greyBags.Add(targetBag.Item1);
        }  
    }
}

count--; // startBag

Console.WriteLine(count);