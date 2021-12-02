using System;

namespace _5_BinaryBoarding_1
{
    public class Seat
    {
        public string String { get; set; }

        public int Column => String
            .Substring(7, 3)
            .Replace('R', '1')
            .Replace('L', '0')
            .ToInt(2);

        public int Row => String
            .Substring(0, 7)
            .Replace('B', '1')
            .Replace('F', '0')
            .ToInt(2);

        public int SeatId => Row * 8 + Column;
    }
}
