namespace P02_SumMatrixColumns
{
    using System;
    using System.Linq;

    public class SumMatrixColumns
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int col = 0; col < matrixSize[1]; col++)
            {
                int columnSum = 0;

                for (int row = 0; row < matrixSize[0]; row++)
                {
                    columnSum += matrix[row, col];
                }

                Console.WriteLine(columnSum);
            }
        }
    }
}
