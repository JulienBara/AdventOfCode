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
    .SelectMany(Mapper)
    .GroupBy(x => x)
    .Select(x => x.Count())
    .Where(x => x > 1)
    .Count()
    ;

Console.WriteLine(result);

IEnumerable<Point> Mapper(Line line)
{
    var length = Math.Sqrt(Math.Pow(line.x2 - line.x1, 2) + Math.Pow(line.y2 - line.y1, 2));
    var directionX = line.x1 == line.x2 ? 0 : (line.x2 - line.x1) / Math.Abs(line.x2 - line.x1);
    var directionY = line.y1 == line.y2 ? 0 : (line.y2 - line.y1) / Math.Abs(line.y2 - line.y1);

    for (int x = line.x1, y = line.y1; x != line.x2 || y != line.y2; x += directionX, y += directionY)
    {
        yield return new Point(x, y);
    }
    yield return new Point(line.x2, line.y2);
}

record Line(int x1, int y1, int x2, int y2);
record Point(int x, int y);
