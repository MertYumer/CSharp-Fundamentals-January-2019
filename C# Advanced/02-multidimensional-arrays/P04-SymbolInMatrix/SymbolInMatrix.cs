namespace P04_SymbolInMatrix
{
    using System;

    public class SymbolInMatrix
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            bool foundSymbol = false;
            int x = -1;
            int y = -1;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine();
                var symbols = input.ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                if (foundSymbol)
                {
                    break;
                }

                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        foundSymbol = true;
                        x = row;
                        y = col;
                        break;
                    }
                }
            }

            if (foundSymbol)
            {
                Console.WriteLine($"({x}, {y})");
            }

            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
