namespace P08_Bombs
{
    using System;
    using System.Linq;

    public class Bombs
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int row = 0; row < n; row++)
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

            var bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                var currentBomb = bombs[i].Split(",");
                int x = int.Parse(currentBomb[0]);
                int y = int.Parse(currentBomb[1]);

                if (matrix[x, y] > 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if ((row != x || col != y) && matrix[row, col] > 0)
                            {
                                if ((row == x - 1 || row == x || row == x + 1) && 
                                    (col == y - 1 || col == y || col == y + 1))
                                {
                                    matrix[row, col] -= matrix[x, y];
                                }
                            }
                        }
                    }

                    matrix[x, y] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
