namespace P01_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < commands[0]; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < commands[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }

            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
