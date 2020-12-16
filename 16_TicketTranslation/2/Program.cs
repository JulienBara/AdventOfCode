using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _16_TicketTranslation_2;

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

var validTickets = new List<List<int>>();
foreach (var nearbyTicket in nearbyTickets)
{
    var ticketIsValid = true;
    foreach (var value in nearbyTicket)
    {
        if(! fields.Any(x => x.Validator(value)))
            ticketIsValid = false;
    }
    if(ticketIsValid)
        validTickets.Add(nearbyTicket.ToList());
}


var possibleFields = fields.Select(x => x.Name).ToList();
var indexesToAssign = new List<int>();
for (int i = 0; i < yourTicket.Count(); i++)
{
    indexesToAssign.Add(i);
}

var indexToField = new Dictionary<int, string>();
while(indexesToAssign.Count > 0)
{
    foreach (var index in new List<int>(indexesToAssign))
    {
        var countPossibleFields = 0;
        string lastPossibleField = null;
        foreach (var possibleField in possibleFields)
        {
            if(validTickets.All(x => fields.First(x => x.Name == possibleField).Validator(x[index])))
            {
                countPossibleFields++;
                lastPossibleField = possibleField;
            }               
        }
        if(countPossibleFields == 1)
        {
            indexesToAssign.Remove(index);
            possibleFields.Remove(lastPossibleField);
            indexToField.Add(index, lastPossibleField);
        }
    }
}

long product = 1;
foreach (var field in indexToField)
{
    if(field.Value.StartsWith("departure"))
        product *= yourTicket.ToList()[field.Key];
}

Console.WriteLine(product);
