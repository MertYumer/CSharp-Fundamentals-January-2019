namespace P04_AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(p => $"{(p * 1.2m):f2}");

            Console.WriteLine(string.Join(Environment.NewLine, prices));
        }
    }
}
