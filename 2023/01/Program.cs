using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var input1File = Path.Combine(".", "input1");

var result1 = File
    .ReadAllLines(input1File)
    .Select(line => line.Where(char.IsDigit))
    .Select(line => line.First().ToString() + line.Last().ToString())
    .Select(line => Int32.Parse(line))
    .Sum()
    ;

System.Console.WriteLine(result1);

var input2File = Path.Combine(".", "input2");

var result2 = File
    .ReadAllLines(input2File)
    .Select(line => Regex.Replace(line,"(zero|one|two|three|four|five|six|seven|eight|nine)", match => {
        switch (match.Value)
        {
            case "zero":
                return "0";
            case "one":
                return "1";
            case "two": 
                return "2";
            case "three":
                return "3";
            case "four":
                return "4";
            case "five":
                return "5";
            case "six":
                return "6";
            case "seven":
                return "7";
            case "eight":
                return "8";
            case "nine":
                return "9";
            default:
                Console.WriteLine(match.Value);
                return match.Value;
        }
    }))
    .Select(line => line.Where(char.IsDigit))
    .Select(line => line.First().ToString() + line.Last().ToString())
    .Select(line => Int32.Parse(line))
    .Sum()
    ;

System.Console.WriteLine(String.Join("\n",result2));