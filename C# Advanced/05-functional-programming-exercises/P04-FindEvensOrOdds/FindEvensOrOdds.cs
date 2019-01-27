namespace P04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            Predicate<int> isEven = n => n % 2 == 0;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string condition = Console.ReadLine();

            var result = new List<int>();

            Enumerable.Range(numbers[0], numbers[1] - numbers[0] + 1)
                .Where(n => condition == "even" ? isEven(n) : !isEven(n))
                .ToList()
                .ForEach(result.Add);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
