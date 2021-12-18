using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile)
    .Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0'))
    .JoinStrings()
    .ToList();

var result = processPacket(input);

Console.WriteLine(result.Item1);

(int, IEnumerable<char>) processPacket(IEnumerable<char> input)
{
    var version = Convert.ToInt32(input.Take(3).JoinStrings(), 2);
    input = input.Skip(3);

    var type = Convert.ToInt32(input.Take(3).JoinStrings(), 2);
    input = input.Skip(3);

    if (type == 4) // literal value
    {
        string startBit;
        do
        {
            startBit = input.Take(1).JoinStrings();
            input = input.Skip(1).ToList();
            input = input.Skip(4).ToList();
        } while (startBit == "1");
    }
    else // operator
    {
        var lengthTypeBit = input.Take(1).JoinStrings();
        input = input.Skip(1).ToList();

        if (lengthTypeBit == "0") // the length is a 15-bit number representing the number of bits in the sub-packets
        {
            var lengthOfSubPackets = Convert.ToInt32(input.Take(15).JoinStrings(), 2);
            input = input.Skip(15).ToList();

            var currentInputLength = input.Count();
            while (currentInputLength - input.Count() < lengthOfSubPackets)
            {
                var (v, s) = processPacket(input);
                version += v;
                input = s;
            }
        }
        else // the length is a 11-bit number representing the number of sub-packets
        {
            var numberOfSubPackets = Convert.ToInt32(input.Take(11).JoinStrings(), 2);
            input = input.Skip(11).ToList();

            for (int i = 0; i < numberOfSubPackets; i++)
            {
                var (v, s) = processPacket(input);
                version += v;
                input = s;
            }
        }
    }

    return (version, input);
}