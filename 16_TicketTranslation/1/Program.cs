using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _16_TicketTranslation_1;

var inputFile = @".\input";

var input = File.ReadAllText(inputFile);

var fields = input
    .Split($"{Environment.NewLine}{Environment.NewLine}")[0]
    .Split(Environment.NewLine)
    .Select(x => new Field {String = x});

var yourTicket = input
    .Split($"{Environment.NewLine}{Environment.NewLine}")[1]
    .Split(Environment.NewLine)[1]
    .Split(",")
    .Select(x => int.Parse(x));

var nearbyTickets = input
    .Split($"{Environment.NewLine}{Environment.NewLine}")[2]
    .Split(Environment.NewLine)
    .Skip(1)
    .Select(x => x
        .Split(",")
        .Select(y => int.Parse(y)));

var sum = 0;
foreach (var nearbyTicket in nearbyTickets)
{
    foreach (var value in nearbyTicket)
    {
        if(! fields.Any(x => x.Validator(value)))
            sum += value;
    }
}

Console.WriteLine(sum);
