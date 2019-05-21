namespace P01_RhombusOfStars
{
    using System;

    public class RhombusOfStars
    {
        public static int n;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                PrintRow(row);
            }

            for (int row = n - 1; row > 0; row--)
            {
                PrintRow(row);
            }
        }

        public static void PrintRow(int row)
        {
            for (int col = 0; col < n - row; col++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < row; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
