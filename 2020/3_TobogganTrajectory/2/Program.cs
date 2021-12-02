using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3_TobogganTrajectory_2
{
    class Program
    {
        public const string InputFile = @".\input";
        public static List<Slope> slopes = new List<Slope>{
            new Slope{ RightPerTurn = 1, DownPerTurn = 1 },
            new Slope{ RightPerTurn = 3, DownPerTurn = 1 },
            new Slope{ RightPerTurn = 5, DownPerTurn = 1 },
            new Slope{ RightPerTurn = 7, DownPerTurn = 1 },
            new Slope{ RightPerTurn = 1, DownPerTurn = 2 },
        };

        static void Main(string[] args)
        {
            var forest = File
                .ReadAllLines(InputFile);

            long multipleTrees = 1;
            foreach (var slope in slopes)
            {
                var countTrees = 0;
                for (int i = 0; i * slope.DownPerTurn < forest.Count(); i++)
                {
                    var rightPosition = i * slope.RightPerTurn;
                    var downPosition = i * slope.DownPerTurn; 
                    if(forest[downPosition][rightPosition % forest[downPosition].Count()] == '#')
                        countTrees++;
                }
                multipleTrees *= countTrees;
            }
            
            System.Console.WriteLine(multipleTrees);
        }
    }
}
