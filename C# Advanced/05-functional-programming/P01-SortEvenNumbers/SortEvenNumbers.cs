namespace P01_SortEvenNumbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var sortedNumbers = input.Where(n => n % 2 == 0).OrderBy(n => n);
            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
