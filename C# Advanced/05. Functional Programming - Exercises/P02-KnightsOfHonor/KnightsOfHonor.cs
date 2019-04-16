namespace P02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
