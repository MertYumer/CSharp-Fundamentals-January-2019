namespace P03_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];
            var square = new int[3, 3];
            int biggestSum = int.MinValue;

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int row = 0; row < matrixSize[0] - 2; row++)
            {
                for (int col = 0; col < matrixSize[1] - 2; col++)
                {
                    int firstElement = matrix[row, col];
                    int secondElement = matrix[row, col + 1];
                    int thirdElement = matrix[row, col + 2];
                    int fourthElement = matrix[row + 1, col];
                    int fifthElement = matrix[row + 1, col + 1];
                    int sixthElement = matrix[row + 1, col + 2];
                    int seventhElement = matrix[row + 2, col];
                    int eightElement = matrix[row + 2, col + 1];
                    int ninthElement = matrix[row + 2, col + 2];
                    int currentSum = firstElement + secondElement + thirdElement + 
                        fourthElement + fifthElement + sixthElement +
                        seventhElement + eightElement + ninthElement;

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        square[0, 0] = firstElement;
                        square[0, 1] = secondElement;
                        square[0, 2] = thirdElement;
                        square[1, 0] = fourthElement;
                        square[1, 1] = fifthElement;
                        square[1, 2] = sixthElement;
                        square[2, 0] = seventhElement;
                        square[2, 1] = eightElement;
                        square[2, 2] = ninthElement;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(square[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
