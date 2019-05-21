namespace P05_SnakeMoves
{
    using System;
    using System.Linq;

    public class SnakeMoves
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[matrixSize[0], matrixSize[1]];
            string snake = Console.ReadLine();
            int snakeIndex = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    snakeIndex++;

                    if (snakeIndex == snake.Length)
                    {
                        snakeIndex = 0;
                    }

                    matrix[row, col] = snake[snakeIndex];
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
