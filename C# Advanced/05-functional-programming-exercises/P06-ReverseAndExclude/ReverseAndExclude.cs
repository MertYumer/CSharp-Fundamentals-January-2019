namespace P06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int delimiter = int.Parse(Console.ReadLine());
            Func<int, bool> isNotDivisable = n => n % delimiter != 0;

            numbers = numbers
                .Where(isNotDivisable)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
