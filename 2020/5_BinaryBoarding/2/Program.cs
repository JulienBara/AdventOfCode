using System;
using System.IO;
using System.Linq;

namespace _5_BinaryBoarding_2
{
    class Program
    {
        public const string InputFile = @".\input";

        static void Main(string[] args)
        {
            var seats = File
                .ReadLines(InputFile)
                .Select(x => new Seat {String = x})
                .OrderBy(x => x.SeatId)
                .ToList()
                ;

            for (int i = 0; i < seats.Count - 1; i++)
            {
                if(seats[i+1].SeatId - seats[i].SeatId == 2){
                    System.Console.WriteLine(seats[i].SeatId + 1);
                    break;
                }
            }          
        }
    }
}
