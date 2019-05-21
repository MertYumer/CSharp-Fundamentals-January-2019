namespace P05_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];
            var square = new int[2, 2];
            int biggestSum = int.MinValue;

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
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
                    int firstElement = matrix[row, col];
                    int secondElement = matrix[row, col + 1];
                    int thirdElement = matrix[row + 1, col];
                    int fourthElement = matrix[row + 1, col + 1];
                    int currentSum = firstElement + secondElement + thirdElement + fourthElement;

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        square[0, 0] = firstElement;
                        square[0, 1] = secondElement;
                        square[1, 0] = thirdElement;
                        square[1, 1] = fourthElement;
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(square[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
