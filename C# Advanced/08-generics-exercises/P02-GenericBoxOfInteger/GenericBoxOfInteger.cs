namespace P02_GenericBoxOfInteger
{
    using System;

    public class GenericBoxOfInteger
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}