namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class JediGalaxy
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimensions[0];
            int y = dimensions[1];

            int[,] matrix = new int[x, y];
            int value = 0;

            for (int row = 0; row < x; row++)
            {
                for (int col = 0; col < y; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            string command = Console.ReadLine();
            long ivoPoints = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];
                var ivo = new Player(ivoRow, ivoCol);

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];
                var evil = new Player(evilRow, evilCol);

                MoveEvil(matrix, evil.Row, evil.Col);
                ivoPoints = MoveIvo(matrix, ivo.Row, ivo.Col, ivoPoints);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivoPoints);
        }

        public static long MoveIvo(int[,] matrix, int ivoRow, int ivoCol, long ivoPoints)
        {
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow < matrix.GetLength(0) && ivoCol >= 0)
                {
                    ivoPoints += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return ivoPoints;
        }

        public static void MoveEvil(int[,] matrix, int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow < matrix.GetLength(0) && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }
    }
}
