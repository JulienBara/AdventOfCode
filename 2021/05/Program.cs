using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result = File
    .ReadAllLines(inputFile)
    .Select(x => x
        .Split(" -> ")
        .Select(y => y
            .Split(",")
            .ToList()
        ).ToList()
    )
    .Select(x => new Line(
        Int32.Parse(x[0][0]),
        Int32.Parse(x[0][1]),
        Int32.Parse(x[1][0]),
        Int32.Parse(x[1][1])
    ))
    .Where(x => x.x1 == x.x2 || x.y1 == x.y2)
    .SelectMany(Mapper)
    .GroupBy(x => x)
    .Select(x => x.Count())
    .Where(x => x > 1)
    .Count()
    ;

Console.WriteLine(result);

IEnumerable<Point> Mapper(Line line)
{
    for (int x = Math.Min(line.x1, line.x2); x <= Math.Max(line.x1, line.x2); x++)
    {
        for (int y = Math.Min(line.y1, line.y2); y <= Math.Max(line.y1, line.y2); y++)
        {
            yield return new Point(x, y);
        }
    }
}

record Line(int x1, int y1, int x2, int y2);
record Point(int x, int y);
