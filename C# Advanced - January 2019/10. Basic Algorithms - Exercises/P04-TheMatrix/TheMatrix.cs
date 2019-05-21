namespace P04_TheMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheMatrix
    {
        public static int rows;
        public static int cols;

        public static void Main()
        {
            var coodrinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            rows = coodrinates[0];
            cols = coodrinates[1];

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            char symbolToFill = char.Parse(Console.ReadLine());
            coodrinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startRow = coodrinates[0];
            int startCol = coodrinates[1];
            char symbolToReplace = matrix[startRow][startCol];

            ColorMatrix(matrix, startRow, startCol, symbolToFill, symbolToReplace);

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static void ColorMatrix(char[][] matrix, int row,
            int col, char symbolToFill, char symbolToReplace)
        {
            if (!ValidCoordinates(row, col) 
                || matrix[row][col] == symbolToFill 
                || matrix[row][col] != symbolToReplace)
            {
                return;
            }

            matrix[row][col] = symbolToFill;
            ColorMatrix(matrix, row + 1, col, symbolToFill, symbolToReplace);
            ColorMatrix(matrix, row - 1, col, symbolToFill, symbolToReplace);
            ColorMatrix(matrix, row, col + 1, symbolToFill, symbolToReplace);
            ColorMatrix(matrix, row, col - 1, symbolToFill, symbolToReplace);
        }

        public static bool ValidCoordinates(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }

    public class Area
    {
        public Area(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }
    }
}
