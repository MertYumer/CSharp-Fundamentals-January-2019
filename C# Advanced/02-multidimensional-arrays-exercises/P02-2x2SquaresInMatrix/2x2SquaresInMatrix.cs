namespace P02_2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[matrixSize[0], matrixSize[1]];
            int squaresCount = 0;

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < matrixSize[0] - 1; row++)
            {
                for (int col = 0; col < matrixSize[1] - 1; col++)
                {
                    char firstElement = matrix[row, col];
                    char secondElement = matrix[row, col + 1];
                    char thirdElement = matrix[row + 1, col];
                    char fourthElement = matrix[row + 1, col + 1];

                    if (firstElement == secondElement && 
                        secondElement == thirdElement && 
                        thirdElement == fourthElement)
                    {
                        squaresCount++;
                    }
                }
            }

            Console.WriteLine(squaresCount);
        }
    }
}
