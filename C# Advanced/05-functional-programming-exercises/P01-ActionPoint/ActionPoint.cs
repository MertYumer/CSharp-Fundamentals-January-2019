namespace P01_ActionPoint
{
    using System;
    using System.Linq;

    public class ActionPoint
    {
        public static void Main()
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
