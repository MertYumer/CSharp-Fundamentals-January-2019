namespace P01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> reversedString = new Stack<char>();

            foreach (var symbol in input)
            {
                reversedString.Push(symbol);
            }

            foreach (var symbol in reversedString)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }
}

