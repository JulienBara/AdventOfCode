using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Aggregate(
        new
        {
            Location = "/",
            Hierarchy = new Dictionary<string, int>() { { "///", 0 } } // after first command we are here
        },
        (acc, line) =>
            line.StartsWith("$ cd ") ?
                new
                {
                    Location = line.Substring("$ cd ".Length) == ".." ?
                        acc.Location.Substring(0, acc.Location.LastIndexOf("/")) :
                        acc.Location + "/" + line.Substring("$ cd ".Length),
                    Hierarchy = acc.Hierarchy,
                } :
            line.StartsWith("$ ls") ?
                new
                {
                    Location = acc.Location,
                    Hierarchy = acc.Hierarchy,
                } :
            line.StartsWith("dir") ?
                new
                {
                    Location = acc.Location,
                    Hierarchy = new Dictionary<string, int>(acc
                        .Hierarchy
                        .ToList()
                        .Append(KeyValuePair.Create(acc.Location + "/" + line.Split(" ").ToList()[1], 0))
                    ),
                } :
                // line is a file
                new
                {
                    Location = acc.Location,
                    Hierarchy = new Dictionary<string, int>(acc
                        .Hierarchy
                        .Select(kv => KeyValuePair.Create(kv.Key, acc.Location.StartsWith(kv.Key) ?
                            kv.Value + Int32.Parse(line.Split(" ").ToList()[0]) :
                            kv.Value
                        ))
                        .ToList()
                    ),
                }
    )
    .Hierarchy
    .Where(x => x.Value < 100000)
    .Sum(x => x.Value);

System.Console.WriteLine(result1);

var result2 = File
    .ReadAllLines(inputFile)
    .Aggregate(
        new
        {
            Location = "/",
            Hierarchy = new Dictionary<string, int>() { { "///", 0 } } // after first command we are here
        },
        (acc, line) =>
            line.StartsWith("$ cd ") ?
                new
                {
                    Location = line.Substring("$ cd ".Length) == ".." ?
                        acc.Location.Substring(0, acc.Location.LastIndexOf("/")) :
                        acc.Location + "/" + line.Substring("$ cd ".Length),
                    Hierarchy = acc.Hierarchy,
                } :
            line.StartsWith("$ ls") ?
                new
                {
                    Location = acc.Location,
                    Hierarchy = acc.Hierarchy,
                } :
            line.StartsWith("dir") ?
                new
                {
                    Location = acc.Location,
                    Hierarchy = new Dictionary<string, int>(acc
                        .Hierarchy
                        .ToList()
                        .Append(KeyValuePair.Create(acc.Location + "/" + line.Split(" ").ToList()[1], 0))
                    ),
                } :
                // line is a file
                new
                {
                    Location = acc.Location,
                    Hierarchy = new Dictionary<string, int>(acc
                        .Hierarchy
                        .Select(kv => KeyValuePair.Create(kv.Key, acc.Location.StartsWith(kv.Key) ?
                            kv.Value + Int32.Parse(line.Split(" ").ToList()[0]) :
                            kv.Value
                        ))
                        .ToList()
                    ),
                }
    )
    .Hierarchy
    .Select(x => x.Value)
    .Aggregate(
        new
        {
            HasBeenInitedByFirst = false,
            MemoryToFree = 0,
            BestDirectory = 70000000
        },
        (acc, folderSpace) =>
            !acc.HasBeenInitedByFirst ?
                new
                {
                    HasBeenInitedByFirst = true,
                    MemoryToFree = 30000000 - 70000000 + folderSpace,
                    BestDirectory = acc.BestDirectory
                } :
                    folderSpace < acc.MemoryToFree ?
                    acc :
                        folderSpace - acc.MemoryToFree > acc.BestDirectory - acc.MemoryToFree ?
                        acc :
                        new
                        {
                            HasBeenInitedByFirst = acc.HasBeenInitedByFirst,
                            MemoryToFree = acc.MemoryToFree,
                            BestDirectory = folderSpace
                        }
    )
    .BestDirectory;

System.Console.WriteLine(result2);
