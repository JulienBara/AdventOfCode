using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputFile = Path.Combine(".", "input");

var input = File
    .ReadAllText(inputFile)
    .Split(Environment.NewLine + Environment.NewLine)
    .Aggregate(
        new { Numbers = new List<int>(), Boards = new List<int[][]>() },
        (accu, line) => accu.Numbers.Count == 0 ?
        new
        {
            Numbers = accu.Numbers
                .Concat(line
                    .Split(",")
                    .Select(x => Int32.Parse(x))
                ).ToList(),
            Boards = accu.Boards
        } :
        new
        {
            Numbers = accu.Numbers,
            Boards = accu.Boards
                .Append(line
                    .Split(Environment.NewLine)
                    .Select(x => x
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(y => Int32.Parse(y))
                        .ToArray()
                    ).ToArray()
                ).ToList()
        }
    );

var endOfGame = input.Numbers
    .Aggregate(
        new
        {
            IsGameEnded = false,
            LosingBoard = 0,
            WinningBoards = input.Boards.Select(x => false).ToList(),
            LastNumer = 0,
            Boards = input.Boards.Select(x => new bool[5, 5]).ToArray()
        },
        (accu, number) =>
        {
            if (accu.IsGameEnded) { return accu; }

            for (int boardIndex = 0; boardIndex < input.Boards.Count; boardIndex++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (input.Boards[boardIndex][i][j] != number) continue;

                        accu.Boards[boardIndex][i, j] = true;

                        if (Enumerable.Range(0, 5).All(x => accu.Boards[boardIndex][i, x])
                        || Enumerable.Range(0, 5).All(x => accu.Boards[boardIndex][x, j]))
                        {
                            accu.WinningBoards[boardIndex] = true;


                            if (accu.WinningBoards.All(x => x))
                            {
                                return new
                                {
                                    IsGameEnded = true,
                                    LosingBoard = boardIndex,
                                    WinningBoards = accu.WinningBoards,
                                    LastNumer = number,
                                    Boards = accu.Boards
                                };
                            }
                        }
                    }
                }
            }
            return accu;
        }
    );

var sumUnmarkedNumbers = 0;
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (!endOfGame.Boards[endOfGame.LosingBoard][i, j])
        {
            sumUnmarkedNumbers += input.Boards[endOfGame.LosingBoard][i][j];
        }
    }
}

Console.WriteLine(sumUnmarkedNumbers * endOfGame.LastNumer);
