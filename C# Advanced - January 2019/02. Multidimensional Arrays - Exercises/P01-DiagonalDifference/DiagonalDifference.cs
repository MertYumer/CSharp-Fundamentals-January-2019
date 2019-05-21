namespace P01_DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int secondIndex = n - 1;

            for (int firstIndex = 0; firstIndex < n; firstIndex++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                primaryDiagonal += input[firstIndex];
                secondaryDiagonal += input[secondIndex];
                secondIndex--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
