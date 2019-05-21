namespace P04_Froggy
{
    using System;
    using System.Linq;

    public class Froggy
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var stones = new Lake(input);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
