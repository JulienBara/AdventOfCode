using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile);
var regexMatches = new Regex(@"target area: x=(?<xMin>-?\d+?)\.\.(?<xMax>-?\d+?), y=(?<yMin>-?\d+?)\.\.(?<yMax>-?\d+?)")
    .Match(input)
    .Groups;
var xMin = Int32.Parse(regexMatches["xMin"].Value);
var xMax = Int32.Parse(regexMatches["xMax"].Value);
var yMin = Int32.Parse(regexMatches["yMin"].Value);
var yMax = Int32.Parse(regexMatches["yMax"].Value);

// (xInitialVelocity, yInitialVelocity, highestY)
var validInitialVelocities = new List<(int, int, int)>();

for (int xInitialVelocity = -1000; xInitialVelocity < 1000; xInitialVelocity++)
{
    for (int yInitialVelocity = -1000; yInitialVelocity < 1000; yInitialVelocity++)
    {
        var x = 0;
        var y = 0;
        var highestY = 0;
        var xVelocity = xInitialVelocity;
        var yVelocity = yInitialVelocity;
        while (x <= xMax && y >= yMin)
        {
            if (xMin <= x
            && x <= xMax
            && yMin <= y
            && y <= yMax)
                validInitialVelocities.Add((xInitialVelocity, yInitialVelocity, highestY));

            x += xVelocity;
            y += yVelocity;
            highestY = Math.Max(highestY, y);
            xVelocity += xVelocity > 0 ? -1 : xVelocity < 0 ? 1 : 0;
            yVelocity += -1;
        }
    }
}

var result = validInitialVelocities
    .OrderByDescending(x => x.Item3)
    .First()
    .Item3;

Console.WriteLine(result);
