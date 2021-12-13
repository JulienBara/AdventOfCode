using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var finalGrid = File
    .ReadAllLines(inputFile)
    .Aggregate(
        new bool[2000, 2000],
        (accu, line) =>
        {
            if (line == "")
                return accu;

            if (line.Contains(","))
            {
                var x = Int32.Parse(line.Split(",")[0]);
                var y = Int32.Parse(line.Split(",")[1]);
                accu[x, y] = true;
                return accu;
            }

            var direction = line.Split(" ")[2].Split("=")[0];
            var position = Int32.Parse(line.Split(" ")[2].Split("=")[1]);


            if (direction == "x")
            {
                var newAccu = new bool[position, accu.GetLength(1)];
                for (int y = 0; y < newAccu.GetLength(1); y++)
                {
                    for (int x = 0; x < newAccu.GetLength(0); x++)
                    {
                        newAccu[x, y] = accu[x, y] || accu[2 * position - x, y];
                    }
                }
                return newAccu;
            }

            if (direction == "y")
            {
                var newAccu = new bool[accu.GetLength(0), position];
                for (int y = 0; y < newAccu.GetLength(1); y++)
                {
                    for (int x = 0; x < newAccu.GetLength(0); x++)
                    {
                        newAccu[x, y] = accu[x, y] || accu[x, 2 * position - y];
                    }
                }
                return newAccu;
            }

            // should not be reached
            return accu;
        }
    );

for (int y = 0; y < finalGrid.GetLength(1); y++)
{
    for (int x = 0; x < finalGrid.GetLength(0); x++)
    {
        Console.Write(finalGrid[x, y] ? "#" : ".");
    }
    Console.Write(Environment.NewLine);
}
