using System;
using System.IO;

var inputFile = @".\input";

var input = File
    .ReadAllLines(inputFile);

var space = new bool[1, 1, input.Length, input[0].Length];

for (int i = 0; i < input.Length; i++)
{ 
    for (int j = 0; j < input[0].Length; j++)
    {
        if(input[i][j] == '#')
            space[0,0,i,j] = true;
    }
}

for (int generation = 0; generation < 6; generation++)
{
    var newSpace = new bool[space.GetLength(0) + 2, space.GetLength(1) + 2, space.GetLength(2) + 2, space.GetLength(3) + 2];

    for (int h = 0; h < newSpace.GetLength(0); h++)
    {
        for (int i = 0; i < newSpace.GetLength(1); i++)
        { 
            for (int j = 0; j < newSpace.GetLength(2); j++)
            {
                for (int k = 0; k < newSpace.GetLength(3); k++)
                {
                    // newSpace[h,i,j,k]
                    var sum = 0;
                    for (int w = -1; w < 2; w++)
                    { 
                        for (int z = -1; z < 2; z++)
                        { 
                            for (int y = -1; y < 2; y++)
                            {
                                for (int x = -1; x < 2; x++)
                                {
                                    if(w == 0 && x == 0 && y == 0 && z == 0) continue;
                                    try
                                    {
                                        if(space[h + w - 1, i + z - 1, j + y - 1, k + x - 1])
                                            sum++;
                                    }
                                    catch (System.Exception) {}
                                }
                            }
                        }
                    }

                    var currentSpace = false;
                    try
                    {
                        currentSpace = space[h-1, i-1, j-1, k-1];
                    }
                    catch (System.Exception) {}

                    if(currentSpace && (sum == 2 || sum == 3))
                    {
                        newSpace[h, i, j, k] = true;
                    }
                    if(! currentSpace && sum == 3)
                    {
                        newSpace[h, i, j, k] = true;
                    }
                }
            }
        }
    }

    space = newSpace;
}

var countTrue = 0;
for (int h = 0; h < space.GetLength(0); h++)
{ 
    for (int i = 0; i < space.GetLength(1); i++)
    { 
        for (int j = 0; j < space.GetLength(2); j++)
        {
            for (int k = 0; k < space.GetLength(3); k++)
            {
                if(space[h,i,j,k]) countTrue++;
            }
        }
    }
}
Console.WriteLine(countTrue);
