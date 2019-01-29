namespace P08_CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            Func<int, int> group = n => Math.Abs(n % 2);
            Action<List<int>> printNumbers = n => Console.WriteLine(string.Join(" ", n));

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(n => n)
                .GroupBy(group)
                .OrderBy(n => n.Key);

            var result = new List<int>();

            foreach (var key in numbers)
            {
                foreach (var number in key)
                {
                    result.Add(number);
                }
            }

            printNumbers(result);
        }
    }
}
