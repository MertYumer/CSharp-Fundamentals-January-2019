namespace P06_Sneaking
{
    using System;

    public class Sneaking
    {
        public static char[][] field;
        public static int samRow;
        public static int samCol;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            field = new char[n][];
            FindSam();

            var directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                MoveEnemies();
                bool samDied = CaughtByEnemy();

                if (samDied)
                {
                    field[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    PrintField();
                    return;
                }

                field[samRow][samCol] = '.';
                bool nikoladzeDied;

                switch (direction)
                {
                    case 'U':
                        samRow--;
                        field[samRow][samCol] = 'S';
                        nikoladzeDied = CheckForNikoladze();

                        if (nikoladzeDied)
                        {
                            return;
                        }

                        break;

                    case 'D':
                        samRow++;
                        field[samRow][samCol] = 'S';
                        nikoladzeDied = CheckForNikoladze();

                        if (nikoladzeDied)
                        {
                            return;
                        }

                        break;

                    case 'L':
                        samCol--;
                        field[samRow][samCol] = 'S';
                        break;

                    case 'R':
                        samCol++;
                        field[samRow][samCol] = 'S';
                        break;
                }
            }
        }

        public static bool CheckForNikoladze()
        {
            for (int col = 0; col < field[samRow].Length; col++)
            {
                if (field[samRow][col] == 'N')
                {
                    field[samRow][col] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintField();

                    return true;
                }
            }

            return false;
        }

        public static void PrintField()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static bool CaughtByEnemy()
        {
            for (int col = 0; col < samCol; col++)
            {
                if (field[samRow][col] == 'b')
                {
                    return true;
                }
            }

            for (int col = samCol + 1; col < field[samRow].Length; col++)
            {
                if (field[samRow][col] == 'd')
                {
                    return true;
                }
            }

            return false;
        }

        public static void MoveEnemies()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            field[row][col] = 'b';
                        }

                        else
                        {
                            field[row][col] = '.';
                            field[row][col - 1] = 'd';
                        }

                        continue;
                    }

                    if (field[row][col] == 'b')
                    {
                        if (col == field[row].Length - 1)
                        {
                            field[row][col] = 'd';
                        }

                        else
                        {
                            field[row][col] = '.';
                            field[row][col + 1] = 'b';
                            col++;
                        }
                    }
                }
            }
        }

        public static void FindSam()
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }
        }
    }
}
