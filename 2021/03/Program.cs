using System;
using System.IO;
using System.Linq;


var inputFile = Path.Combine(".", "input");
var lines = File.ReadAllLines(inputFile);


var validOxygens = lines.ToList();
for (int i = 0; i < lines[0].Length && validOxygens.Count > 1; i++)
{
    var treshold = validOxygens.Count / 2.0;
    var oneCount = validOxygens.Where(x => x[i] == '1').Count();
    var mostCommonBit = oneCount >= treshold ? '1' : '0';
    validOxygens = validOxygens.Where(x => x[i] == mostCommonBit).ToList();
}
var gamma = validOxygens.First();
int gammaRate = Convert.ToInt32(gamma, 2);


var validCo2 = lines.ToList();
for (int i = 0; i < lines[0].Length && validCo2.Count > 1; i++)
{
    var treshold = validCo2.Count / 2.0;
    var oneCount = validCo2.Where(x => x[i] == '1').Count();
    var mostCommonBit = oneCount >= treshold ? '1' : '0';
    validCo2 = validCo2.Where(x => x[i] != mostCommonBit).ToList();
}
var epsilon = validCo2.First();
int epsilonRate = Convert.ToInt32(epsilon, 2);


Console.WriteLine(gammaRate * epsilonRate);
