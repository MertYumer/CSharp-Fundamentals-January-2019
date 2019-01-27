namespace P03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]));

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
