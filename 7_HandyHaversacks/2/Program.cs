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

var whiteBags = bags.Keys.ToList();
var greyBags = new List<string>();
var blackBags = new List<string>();

var startBag = "shiny gold";
whiteBags.Remove(startBag);
greyBags.Add(startBag);

while(greyBags.Count > 0)
{
    var greyBag = greyBags.First();
    greyBags.Remove(greyBag);
    blackBags.Add(greyBag);
    var containingBags = whiteBags
        .Where(x => bags[x].Targets.Contains(greyBag))
        .ToList();
    foreach (var containingBag in containingBags)
    {
        whiteBags.Remove(containingBag);
        greyBags.Add(containingBag);
    }
}

blackBags.Remove(startBag);

Console.WriteLine(blackBags.Count);