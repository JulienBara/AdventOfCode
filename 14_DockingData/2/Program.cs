using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var instructions = File.ReadAllLines(inputFile);

var mask = new char[36];
var memset = new Dictionary<UInt64, UInt64>();

foreach (var instruction in instructions)
{
    if(instruction.StartsWith("mask"))
    {
        mask = instruction.Substring("mask = ".Length).ToCharArray();
        continue;
    };

    var value = UInt64.Parse(instruction.Split(' ')[2]);

    var memsetAddress = Convert.ToString(Int64.Parse(instruction.Split('[', ']')[1]), 2);

    while(memsetAddress.Length < 36)
        memsetAddress = "0" + memsetAddress;

    var memsetAddressResult = new char[36];
    for (int i = 0; i < mask.Length; i++)
    {
        if(mask[mask.Length-i-1] == '1')
            memsetAddressResult[mask.Length-i-1] = '1';
        else if(mask[mask.Length-i-1] == 'X')
            memsetAddressResult[mask.Length-i-1] = 'X';
        else
            memsetAddressResult[mask.Length-i-1] = memsetAddress[mask.Length-i-1];
    }

    var possibleMemsetAddresses = new List<List<char>>(); 
    possibleMemsetAddresses.Add(new List<char>());
    for (int i = 0; i < memsetAddressResult.Length; i++)
    {
        if(memsetAddressResult[i] != 'X'){
            foreach (var possibleMemsetAddress in possibleMemsetAddresses)
            {
                possibleMemsetAddress.Add(memsetAddressResult[i]);
            }
        }
        else
        {
            foreach (var possibleMemsetAddress in possibleMemsetAddresses.ToList())
            {
                possibleMemsetAddresses.Add(possibleMemsetAddress.Append('1').ToList());
                possibleMemsetAddress.Add('0');
            }
        }
    }
    foreach (var possibleMemsetAddress in possibleMemsetAddresses)
    {
        memset[Convert.ToUInt64(new String(possibleMemsetAddress.ToArray()), 2)] = value;
    }
}

UInt64 sum = 0;
foreach (var mem in memset)
{
    sum += mem.Value;
}

Console.WriteLine(sum);