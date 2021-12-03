using System;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");
var lines = File.ReadAllLines(inputFile);

var oneCounts = new int[lines[0].Length];
foreach (var line in lines)
{
    for (int i = 0; i < line.Count(); i++)
    {
        if (line[i] == '1') oneCounts[i]++;
    }
}

var treshold = lines.Length / 2;
var gamma = String.Join("", oneCounts.Select(x => x > treshold ? "1" : "0"));
var epsilon = String.Join("", oneCounts.Select(x => x > treshold ? "0" : "1"));

int gammaRate = Convert.ToInt32(gamma, 2);
int epsilonRate = Convert.ToInt32(epsilon, 2);

Console.WriteLine(gammaRate * epsilonRate);
