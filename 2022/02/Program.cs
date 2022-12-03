using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var result1 = File
    .ReadAllLines(inputFile)
    .Select(x => x.Split())
    .Select(x => {
        if (x[0] == "A" && x[1] == "X") { return 1 + 3; }
        if (x[0] == "A" && x[1] == "Y") { return 2 + 6; }
        if (x[0] == "A" && x[1] == "Z") { return 3 + 0; }

        if (x[0] == "B" && x[1] == "X") { return 1 + 0; }
        if (x[0] == "B" && x[1] == "Y") { return 2 + 3; }
        if (x[0] == "B" && x[1] == "Z") { return 3 + 6; }

        if (x[0] == "C" && x[1] == "X") { return 1 + 6; }
        if (x[0] == "C" && x[1] == "Y") { return 2 + 0; }
        if (x[0] == "C" && x[1] == "Z") { return 3 + 3; }

        throw new Exception("should not happen");
    })
    .Sum();

System.Console.WriteLine(result1);

var result2 = File
    .ReadAllLines(inputFile)
    .Select(x => x.Split())
    .Select(x => {
        if (x[0] == "A" && x[1] == "X") { return 3 + 0; }
        if (x[0] == "A" && x[1] == "Y") { return 1 + 3; }
        if (x[0] == "A" && x[1] == "Z") { return 2 + 6; }

        if (x[0] == "B" && x[1] == "X") { return 1 + 0; }
        if (x[0] == "B" && x[1] == "Y") { return 2 + 3; }
        if (x[0] == "B" && x[1] == "Z") { return 3 + 6; }

        if (x[0] == "C" && x[1] == "X") { return 2 + 0; }
        if (x[0] == "C" && x[1] == "Y") { return 3 + 3; }
        if (x[0] == "C" && x[1] == "Z") { return 1 + 6; }

        throw new Exception("should not happen");
    })
    .Sum();

System.Console.WriteLine(result2);
