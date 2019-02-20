namespace P03_ConnectedAreasInMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ConnectedAreasInMatrix
    {
        public static int rows;
        public static int cols;

        public static void Main()
        {
            var areas = new List<Area>();
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == '-')
                    {
                        var area = new Area(row, col);
                        int size = 0;
                        FindAreaSize(matrix, row, col, ref size);
                        area.Size = size;
                        areas.Add(area);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            areas = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}," +
                    $" {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void FindAreaSize(char[][] matrix, int row, int col, ref int size)
        {
            if (!ValidCoordinates(row, col)
                || matrix[row][col] == '*'
                || matrix[row][col] == 'X')
            {
                return;
            }

            matrix[row][col] = 'X';
            size++;

            FindAreaSize(matrix, row + 1, col, ref size);
            FindAreaSize(matrix, row - 1, col, ref size);
            FindAreaSize(matrix, row, col + 1, ref size);
            FindAreaSize(matrix, row, col - 1, ref size);
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
