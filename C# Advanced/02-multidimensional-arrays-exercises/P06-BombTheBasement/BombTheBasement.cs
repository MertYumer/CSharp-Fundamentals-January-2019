namespace P06_BombTheBasement
{
    using System;
    using System.Linq;

    public class BombTheBasement
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0], matrixSize[1]];

            var bombParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = bombParameters[0];
            int y = bombParameters[1];
            int radius = bombParameters[2];
            matrix[bombParameters[0], bombParameters[1]] = 1;
            
            for (int row = 0; row < matrixSize[0]; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    double result = Math.Pow((row - x), 2) + Math.Pow((col - y), 2);

                    if (result <= Math.Pow(radius, 2))
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int row = 1; row < matrixSize[0]; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        int rowindex = row;

                        while (true)
                        {
                            rowindex--;

                            if (rowindex < 0)
                            {
                                break;
                            }

                            else if (matrix[rowindex, col] == 1)
                            {
                                break;
                            }

                            else
                            {
                                matrix[rowindex, col] = 1;
                                matrix[rowindex + 1, col] = 0;
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < matrixSize[0]; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
