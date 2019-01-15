namespace P01_SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];
            int sum = 0;

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var column = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sum += column.Sum();
            }

            Console.WriteLine(matrixSize[0]);
            Console.WriteLine(matrixSize[1]);
            Console.WriteLine(sum);
        }
    }
}
