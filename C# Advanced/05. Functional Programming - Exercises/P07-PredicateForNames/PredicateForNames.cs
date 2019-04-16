namespace P07_PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            Func<string, bool> checkLength = n => n.Length <= length;
            Action<string> printName = n => Console.WriteLine(n);

            Console.ReadLine()
                .Split()
                .Where(checkLength)
                .ToList()
                .ForEach(printName);
        }
    }
}
