using System;
using System.IO;
using System.Linq;

namespace _3_TobogganTrajectory_2
{
    class Program
    {
        public const string InputFile = @".\input";
        public const int rightPerTurn = 3;
        public const int downPerTurn = 1;

        static void Main(string[] args)
        {
            var forest = File
                .ReadAllLines(InputFile);

            var countTrees = 0;

            for (int i = 0; i < forest.Count(); i++)
            {
                var rightPosition = i * rightPerTurn;
                var downPosition = i * downPerTurn;
                if(forest[downPosition][rightPosition % forest[downPosition].Count()] == '#')
                    countTrees++;
            }

            System.Console.WriteLine(countTrees);
        }
    }
}
