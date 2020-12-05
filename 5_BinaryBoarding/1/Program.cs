using System;
using System.IO;
using System.Linq;

namespace _5_BinaryBoarding_1
{
    class Program
    {
        public const string InputFile = @".\input";

        static void Main(string[] args)
        {
            var higherSeatId = File
                .ReadLines(InputFile)
                .Select(x => new Seat {String = x})
                .OrderByDescending(x => x.SeatId)
                .First()
                .SeatId
                ;

            System.Console.WriteLine(higherSeatId);
        }
    }
}
