namespace P03_PrimaryDiagonal
{
    using System;
    using System.Linq;

    public class PrimaryDiagonal
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                sum += row[i];
            }

            Console.WriteLine(sum);
        }
    }
}
