namespace P04_MatrixShuffling
{
    using System;
    using System.Linq;

    public class MatrixShuffling
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                else if (command[0] == "swap" && command.Length == 5)
                {
                    int firstRowIndex = int.Parse(command[1]);
                    int firstColIndex = int.Parse(command[2]);
                    int secondRowIndex = int.Parse(command[3]);
                    int secondColIndex = int.Parse(command[4]);

                    if ((firstRowIndex < 0 || firstRowIndex >= matrixSize[0]) ||
                        (secondRowIndex < 0 || secondRowIndex >= matrixSize[0]) ||
                        (firstColIndex < 0 || firstColIndex >= matrixSize[1]) ||
                        (secondRowIndex < 0 || secondRowIndex >= matrixSize[1]))
                    {
                        Console.WriteLine("Invalid input!");
                    }

                    else
                    {
                        var tempElement = matrix[firstRowIndex, firstColIndex];
                        matrix[firstRowIndex, firstColIndex] = matrix[secondRowIndex, secondColIndex];
                        matrix[secondRowIndex, secondColIndex] = tempElement;

                        for (int row = 0; row < matrixSize[0]; row++)
                        {
                            for (int col = 0; col < matrixSize[1]; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
