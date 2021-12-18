using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile);
var regexMatches = new Regex(@"^target area: x=(?<xMin>-?\d+?)\.\.(?<xMax>-?\d+?), y=(?<yMin>-?\d+?)\.\.(?<yMax>-?\d+?)$")
    .Match(input)
    .Groups;
var xMin = Int32.Parse(regexMatches["xMin"].Value);
var xMax = Int32.Parse(regexMatches["xMax"].Value);
var yMin = Int32.Parse(regexMatches["yMin"].Value);
var yMax = Int32.Parse(regexMatches["yMax"].Value);

// (xInitialVelocity, yInitialVelocity)
var validInitialVelocities = new List<(int, int)>();

for (int xInitialVelocity = 0; xInitialVelocity < 100; xInitialVelocity++)
{
    for (int yInitialVelocity = -1000; yInitialVelocity < 1000; yInitialVelocity++)
    {
        var x = 0;
        var y = 0;
        var xVelocity = xInitialVelocity;
        var yVelocity = yInitialVelocity;
        while (x <= xMax && y >= yMin)
        {
            x += xVelocity;
            y += yVelocity;
            xVelocity += xVelocity > 0 ? -1 : xVelocity < 0 ? 1 : 0;
            yVelocity += -1;

            if (xMin <= x
            && x <= xMax
            && yMin <= y
            && y <= yMax)
            {
                validInitialVelocities.Add((xInitialVelocity, yInitialVelocity));
                break;
            }
        }
    }
}

var result = validInitialVelocities
    .Count();

Console.WriteLine(result);
