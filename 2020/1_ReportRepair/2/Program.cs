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
                .Select(x => System.Int32.Parse(x))
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i; j < numbers.Count; j++)
                {
                    for (int k = j; k < numbers.Count; k++)
                    {
                        if(numbers[i] + numbers[j] + numbers[k] == SumToFind)
                        {
                            System.Console.WriteLine(numbers[i] * numbers[j] * numbers[k]);
                            return;
                        }
                    }
                }
            }
        }
    }
}
