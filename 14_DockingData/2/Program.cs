using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var instructions = File.ReadAllLines(inputFile);

var mask = new char[36];
var memset = new Dictionary<int, UInt64>();

foreach (var instruction in instructions)
{
    if(instruction.StartsWith("mask"))
    {
        mask = instruction.Substring("mask = ".Length).ToCharArray();
        continue;
    }

    var memsetAddress = int.Parse(instruction.Split('[', ']')[1]);
    var binary = Convert.ToString(Int64.Parse(instruction.Split(' ')[2]), 2);

    while(binary.Length < 36)
        binary = "0" + binary;

    var value = new char[36];
    for (int i = 0; i < mask.Length; i++)
    {
        if(mask[mask.Length-i-1] != 'X')
            value[mask.Length-i-1] = mask[mask.Length-i-1];
        else
            value[mask.Length-i-1] = binary[mask.Length-i-1];
    }
    memset[memsetAddress] = Convert.ToUInt64(new String(value), 2);
}

UInt64 sum = 0;
foreach (var mem in memset)
{
    sum += mem.Value;
}


Console.WriteLine(sum);