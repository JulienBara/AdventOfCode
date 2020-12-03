using System.IO;
using System.Linq;

namespace _1_ReportRepair
{
    class Program
    {
        public const string InputFile = @".\input";
        public const int SumToFind = 2020;

        static void Main(string[] args)
        {
            var numbers = File
                .ReadAllLines(InputFile)
                .Select(x => System.Int32.Parse(x));

            var lowerNumbersStack = numbers
                .Where(x => x < SumToFind / 2)
                .OrderByDescending(x => x)
                .ToList();
            var higherNumbersStack = numbers
                .Where(x => x > SumToFind / 2)
                .OrderBy(x => x)
                .ToList();

            while(lowerNumbersStack.Count > 0 && higherNumbersStack.Count > 0)
            {
                var lowerNumber = lowerNumbersStack.First();
                var higherNumber = higherNumbersStack.First();

                switch (lowerNumber + higherNumber)
                {
                    case int sum when sum > SumToFind:
                        lowerNumbersStack.RemoveAt(0);
                        break;
                    case int sum when sum < SumToFind:
                        higherNumbersStack.RemoveAt(0);
                        break;
                    default:
                        System.Console.WriteLine(lowerNumber * higherNumber);
                        return;
                }
            }
        }
    }
}
