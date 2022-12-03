using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Select(x => (
        x.Take(x.Length / 2),
        x.Skip(x.Length / 2)
    ))
    .Select(x => {
        foreach (var item in x.Item2)
        {
            if(x.Item1.Contains(item)) {
                return item.ToString();
            }
        }

        throw new Exception("should not happen");
    })
    .Select(x => Encoding.ASCII.GetBytes(x)[0])
    .Select(x => 
        x > 96 ?
            x - 96 : // 'a' = 97
            26 + x - 64 // 'A' = 65
    )
    .Sum();

System.Console.WriteLine(result1);

var result2 = File
    .ReadAllLines(inputFile)
    .Chunk(3)
    .Select(x => {
        foreach (var i in x[2])
        {
            if(x[1].Contains(i)) {
                if(x[0].Contains(i)) {
                    return i.ToString();
                }       
            }
        }

        throw new Exception("should not happen");
    })
    .Select(x => Encoding.ASCII.GetBytes(x)[0])
    .Select(x => 
        x > 96 ?
            x - 96 : // 'a' = 97
            26 + x - 64 // 'A' = 65
    )
    .Sum();

System.Console.WriteLine(result2);
