namespace P03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Func<string, bool> isUpper = w => char.IsUpper(w[0]);

            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper);

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
