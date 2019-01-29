namespace P04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string condition = Console.ReadLine();

            Func<int, bool> filter = n => condition == "even" ? n % 2 == 0 : n % 2 != 0;

            var result = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                result.Add(i);
            }

            Console.WriteLine(string.Join(" ", result.Where(filter)));
        }
    }
}
