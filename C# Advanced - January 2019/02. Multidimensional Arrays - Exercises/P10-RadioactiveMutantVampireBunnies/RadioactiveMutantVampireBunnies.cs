namespace P10_RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveMutantVampireBunnies
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[matrixSize[0], matrixSize[1]];
            int playerRow = -1;
            int playerCol = -1;
            bool playerWon = false;
            bool playerLost = false;
            var bunnies = new List<Bunny>();

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];

                    if (elements[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        var bunny = new Bunny(row, col);
                        bunnies.Add(bunny);
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                matrix[playerRow, playerCol] = '.';

                switch (commands[i])
                {
                    case 'U':
                        if (playerRow == 0)
                        {
                            playerWon = true;
                        }

                        else if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            playerLost = true;
                            playerRow--;
                        }

                        else
                        {
                            matrix[playerRow - 1, playerCol] = 'P';
                            playerRow--;
                        }

                        break;

                    case 'D':
                        if (playerRow == matrixSize[0] - 1)
                        {
                            playerWon = true;
                        }

                        else if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            playerLost = true;
                            playerRow++;
                        }

                        else
                        {
                            matrix[playerRow + 1, playerCol] = 'P';
                            playerRow++;
                        }

                        break;

                    case 'L':
                        if (playerCol == 0)
                        {
                            playerWon = true;
                        }

                        else if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            playerLost = true;
                            playerCol--;
                        }

                        else
                        {
                            matrix[playerRow, playerCol - 1] = 'P';
                            playerCol--;
                        }

                        break;

                    case 'R':
                        if (playerCol == matrixSize[1] - 1)
                        {
                            playerWon = true;
                        }

                        else if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            playerLost = true;
                            playerCol++;
                        }

                        else
                        {
                            matrix[playerRow, playerCol + 1] = 'P';
                            playerCol++;
                        }

                        break;
                }

                int bunniesCount = bunnies.Count;

                for (int j = 0; j < bunniesCount; j++)
                {
                    int row = bunnies[j].X;
                    int col = bunnies[j].Y;

                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == 'P' && playerWon == false)
                        {
                            playerLost = true;
                            playerRow = row - 1;
                            playerCol = col;
                        }

                        int bunnyIndex = bunnies.FindIndex(b => b.X == row - 1 && b.Y == col);

                        if (bunnyIndex == -1)
                        {
                            SpreadBunnies(row - 1, col, matrix, bunnies);
                        }
                    }

                    if (row + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row + 1, col] == 'P' && playerWon == false)
                        {
                            playerLost = true;
                            playerRow = row + 1;
                            playerCol = col;
                        }

                        int bunnyIndex = bunnies.FindIndex(b => b.X == row + 1 && b.Y == col);

                        if (bunnyIndex == -1)
                        {
                            SpreadBunnies(row + 1, col, matrix, bunnies);
                        }
                    }

                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == 'P' && playerWon == false)
                        {
                            playerLost = true;
                            playerRow = row;
                            playerCol = col - 1;
                        }

                        int bunnyIndex = bunnies.FindIndex(b => b.X == row && b.Y == col - 1);

                        if (bunnyIndex == -1)
                        {
                            SpreadBunnies(row, col - 1, matrix, bunnies);
                        }
                    }

                    if (col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] == 'P' && playerWon == false)
                        {
                            playerLost = true;
                            playerRow = row;
                            playerCol = col + 1;
                        }

                        int bunnyIndex = bunnies.FindIndex(b => b.X == row && b.Y == col + 1);

                        if (bunnyIndex == -1)
                        {
                            SpreadBunnies(row, col + 1, matrix, bunnies);
                        }
                    }
                }

                if (playerWon || playerLost)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }

                        Console.WriteLine();
                    }

                    if (playerWon)
                    {
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                    }

                    else
                    {
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                    }

                    break;
                }
            }
        }

        public static void SpreadBunnies(int row, int col, char[,] matrix, List<Bunny> bunnies)
        {
            matrix[row, col] = 'B';
            var newBunny = new Bunny(row, col);
            bunnies.Add(newBunny);
        }
    }

    public class Bunny
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Bunny(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
