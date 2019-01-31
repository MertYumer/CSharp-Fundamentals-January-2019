namespace P08_CustomComparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)) + " " +
                string.Join(" ", numbers
                .Where(n => n % 2 != 0)
                .OrderBy(n => n)));
        }
    }
}
