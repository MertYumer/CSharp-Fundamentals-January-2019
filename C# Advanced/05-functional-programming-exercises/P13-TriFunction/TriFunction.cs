namespace P13_TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            var name = Console.ReadLine()
                .Split()
                .Where(x => x.Sum(y => y) >= sum)
                .FirstOrDefault();

            Console.WriteLine(name);
        }
    }
}
