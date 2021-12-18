using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

var inputFile = Path.Combine(".", "input");

var input = File.ReadAllText(inputFile)
    .Select(x => Convert.ToString(Convert.ToInt64(x.ToString(), 16), 2).PadLeft(4, '0'))
    .JoinStrings()
    .ToList();

var result = processPacket(input);

Console.WriteLine(result.Item1);

(long, IEnumerable<char>) processPacket(IEnumerable<char> input)
{
    var version = Convert.ToInt64(input.Take(3).JoinStrings(), 2);
    input = input.Skip(3);

    var type = Convert.ToInt64(input.Take(3).JoinStrings(), 2);
    input = input.Skip(3);

    if (type == 4) // literal value
    {
        string startBit;
        var valueBinaryRepresentation = "";
        do
        {
            startBit = input.Take(1).JoinStrings();
            input = input.Skip(1).ToList();
            valueBinaryRepresentation += input.Take(4).JoinStrings();
            input = input.Skip(4).ToList();
        } while (startBit == "1");

        var value = Convert.ToInt64(valueBinaryRepresentation, 2);
        return (value, input);
    }
    else // operator
    {
        var lengthTypeBit = input.Take(1).JoinStrings();
        input = input.Skip(1).ToList();

        if (lengthTypeBit == "0") // the length is a 15-bit number representing the number of bits in the sub-packets
        {
            var lengthOfSubPackets = Convert.ToInt64(input.Take(15).JoinStrings(), 2);
            input = input.Skip(15).ToList();

            var currentInputLength = input.Count();
            var values = new List<long>();
            while (currentInputLength - input.Count() < lengthOfSubPackets)
            {
                var (value, s) = processPacket(input);
                values.Add(value);
                input = s;
            }

            return (computeOperator(type, values), input);
        }
        else // the length is a 11-bit number representing the number of sub-packets
        {
            var numberOfSubPackets = Convert.ToInt64(input.Take(11).JoinStrings(), 2);
            input = input.Skip(11).ToList();

            var values = new List<long>();
            for (int i = 0; i < numberOfSubPackets; i++)
            {
                var (value, s) = processPacket(input);
                values.Add(value);
                input = s;
            }
            return (computeOperator(type, values), input);
        }
    }
}

long computeOperator(long operatorId, List<long> values)
{
    switch (operatorId)
    {
        case 0:
            return values.Sum();
        case 1:
            return values.Aggregate((long)1, (accu, v) => accu *= v);
        case 2:
            return values.Min();
        case 3:
            return values.Max();
        case 5:
            return values[0] > values[1] ? 1 : 0;
        case 6:
            return values[0] < values[1] ? 1 : 0;
        case 7:
            return values[0] == values[1] ? 1 : 0;
    }
    return 0;
}