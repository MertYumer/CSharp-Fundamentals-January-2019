namespace P03_GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericSwapMethodStrings
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);
                list.Add(box);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var tempBox = list[indexes[0]];
            list[indexes[0]] = list[indexes[1]];
            list[indexes[1]] = tempBox;

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
