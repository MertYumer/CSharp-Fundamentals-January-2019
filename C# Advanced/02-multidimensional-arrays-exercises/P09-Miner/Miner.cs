namespace P09_Miner
{
    using System;
    using System.Linq;

    public class Miner
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;
            int coals = 0;

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];

                    if (elements[col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    else if (elements[col] == 'c')
                    {
                        coals++;
                    }
                }
            }

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (playerRow > 0)
                        {
                            if (matrix[playerRow - 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow - 1}, {playerCol})");
                                return;
                            }

                            else if (matrix[playerRow - 1, playerCol] == 'c')
                            {
                                coals--;

                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({playerRow - 1}, {playerCol})");
                                    return;
                                }
                            }

                            matrix[playerRow - 1, playerCol] = 's';
                            matrix[playerRow, playerCol] = '*';
                            playerRow -= 1;
                        }

                        break;

                    case "down":
                        if (playerRow < n - 1)
                        {
                            if (matrix[playerRow + 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow + 1}, {playerCol})");
                                return;
                            }

                            else if (matrix[playerRow + 1, playerCol] == 'c')
                            {
                                coals--;

                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({playerRow + 1}, {playerCol})");
                                    return;
                                }
                            }

                            matrix[playerRow + 1, playerCol] = 's';
                            matrix[playerRow, playerCol] = '*';
                            playerRow += 1;
                        }

                        break;

                    case "left":
                        if (playerCol > 0)
                        {
                            if (matrix[playerRow, playerCol - 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol - 1})");
                                return;
                            }

                            else if (matrix[playerRow, playerCol - 1] == 'c')
                            {
                                coals--;

                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol - 1})");
                                    return;
                                }
                            }

                            matrix[playerRow, playerCol - 1] = 's';
                            matrix[playerRow, playerCol] = '*';
                            playerCol -= 1;
                        }

                        break;

                    case "right":
                        if (playerCol < n - 1)
                        {
                            if (matrix[playerRow, playerCol + 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol + 1})");
                                return;
                            }

                            else if (matrix[playerRow, playerCol + 1] == 'c')
                            {
                                coals--;

                                if (coals == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol + 1})");
                                    return;
                                }
                            }

                            matrix[playerRow, playerCol + 1] = 's';
                            matrix[playerRow, playerCol] = '*';
                            playerCol += 1;
                        }

                        break;
                }
            }

            Console.WriteLine($"{coals} coals left. ({playerRow}, {playerCol})");
        }
    }
}
