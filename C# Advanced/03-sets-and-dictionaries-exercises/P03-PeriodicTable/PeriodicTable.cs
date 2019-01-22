namespace P03_PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            var sortedSet = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    sortedSet.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", sortedSet));
        }
    }
}
