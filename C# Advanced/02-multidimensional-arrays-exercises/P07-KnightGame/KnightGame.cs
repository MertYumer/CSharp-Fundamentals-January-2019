namespace P07_KnightGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnightGame
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var knights = new List<Knight>();
            
            int removedKnights = 0;

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'K')
                    {
                        var knight = new Knight(row, col);
                        knights.Add(knight);
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'K')
                    {
                        var knight = knights.FirstOrDefault(k => k.X == row && k.Y == col);

                        if (row - 2 >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row - 2, col - 1] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row - 2 >= 0 && col + 1 < n)
                        {
                            if (matrix[row - 2, col + 1] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row - 1 >= 0 && col - 2 >= 0)
                        {
                            if (matrix[row - 1, col - 2] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row - 1 >= 0 && col + 2 < n)
                        {
                            if (matrix[row - 1, col + 2] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row + 1 < n && col - 2 >= 0)
                        {
                            if (matrix[row + 1, col - 2] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row + 1 < n && col + 2 < n)
                        {
                            if (matrix[row + 1, col + 2] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row + 2 < n && col - 1 >= 0)
                        {
                            if (matrix[row + 2, col - 1] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }

                        if (row + 2 < n && col + 1 < n)
                        {
                            if (matrix[row + 2, col + 1] == 'K')
                            {
                                knight.Attacks++;
                            }
                        }
                    }
                }
            }

            while (true)
            {
                knights = knights.OrderByDescending(k => k.Attacks).ToList();
                matrix[knights[0].X, knights[0].Y] = '0';
                knights.RemoveAt(0);
                removedKnights++;
                bool possibleAttack = false;

                foreach (var knight in knights)
                {
                    int row = knight.X;
                    int col = knight.Y;

                    if (row - 2 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 2, col - 1] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row - 2 >= 0 && col + 1 < n)
                    {
                        if (matrix[row - 2, col + 1] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row - 1 >= 0 && col - 2 >= 0)
                    {
                        if (matrix[row - 1, col - 2] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row - 1 >= 0 && col + 2 < n)
                    {
                        if (matrix[row - 1, col + 2] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row + 1 < n && col - 2 >= 0)
                    {
                        if (matrix[row + 1, col - 2] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row + 1 < n && col + 2 < n)
                    {
                        if (matrix[row + 1, col + 2] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row + 2 < n && col - 1 >= 0)
                    {
                        if (matrix[row + 2, col - 1] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }

                    if (row + 2 < n && col + 1 < n)
                    {
                        if (matrix[row + 2, col + 1] == 'K')
                        {
                            possibleAttack = true;
                        }
                    }
                }

                if (!possibleAttack)
                {
                    Console.WriteLine(removedKnights);
                    return;
                }
            }
        }
    }

    public class Knight
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Attacks { get; set; }

        public Knight(int x, int y)
        {
            X = x;
            Y = y;
            Attacks = 0;
        }
    }
}
