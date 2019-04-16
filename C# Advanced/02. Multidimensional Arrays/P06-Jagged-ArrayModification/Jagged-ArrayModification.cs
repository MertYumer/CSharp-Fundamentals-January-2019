namespace P06_Jagged_ArrayModification
{
    using System;
    using System.Linq;

    public class JaggedArrayModification
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                int x = int.Parse(command[1]);
                int y = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (x < 0 || y < 0 || x >= n || y >= n)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (command[0] == "Add")
                {
                    matrix[x, y] += value;
                }

                else if (command[0] == "Subtract")
                {
                    matrix[x, y] -= value;
                }
            }

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
