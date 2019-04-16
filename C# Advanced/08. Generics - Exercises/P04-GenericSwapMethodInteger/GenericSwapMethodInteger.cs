namespace P04_GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericSwapMethodInteger
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>();

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
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
