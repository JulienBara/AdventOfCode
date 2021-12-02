using System;
using System.IO;
using System.Linq;

var inputFile = @".\input";

var input = File
    .ReadAllLines(inputFile);

var matrix = new bool?[input.Length,input[0].Length];// default value: null

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[0].Length; j++)
    {
        var c = input[i][j];
        if (c == 'L')
            matrix[i,j] = false;    
    }
}

var matrixChanged = true;

while(matrixChanged)
{
    var nextMatrix = new bool?[input.Length,input[0].Length];
    matrixChanged = false;
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[0].Length; j++)
        {
            var sum = 0
                + (i-1>=0 && j-1>=0 && matrix[i-1,j-1] == true ? 1 : 0)
                + (i-1>=0 && matrix[i-1,j] == true ? 1 : 0)
                + (i-1>=0 && j+1<input[0].Length && matrix[i-1,j+1] == true ? 1 : 0)
                + (j-1>=0 && matrix[i,j-1] == true ? 1 : 0)
                + (j+1<input[0].Length && matrix[i,j+1] == true ? 1 : 0)
                + (i+1<input.Length && j-1>=0 && matrix[i+1,j-1] == true ? 1 : 0)
                + (i+1<input.Length && matrix[i+1,j] == true ? 1 : 0)
                + (i+1<input.Length && j+1<input[0].Length && matrix[i+1,j+1] == true ? 1 : 0);
            nextMatrix[i,j] = matrix[i,j];
            switch (matrix[i,j])
            {
                case true:
                    if(sum >= 4)
                    {
                        nextMatrix[i,j] = false;
                        matrixChanged = true;
                    }  
                    break;
                case false:
                    if(sum == 0)
                    {
                        nextMatrix[i,j] = true;
                        matrixChanged = true;
                    }
                    break;
            }
        }
    }
    matrix = nextMatrix;
}

var finalSum = 0;
for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[0].Length; j++)
    {
        if (matrix[i,j] == true)
            finalSum++;    
    }
}

Console.WriteLine(finalSum);
