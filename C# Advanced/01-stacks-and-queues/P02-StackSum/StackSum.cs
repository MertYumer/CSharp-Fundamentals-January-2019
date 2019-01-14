namespace P02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);

            while (true)
            {
                var input = Console.ReadLine().Split();
                string command = input[0].ToLower();

                switch (command)
                {
                    case "add":
                        stack.Push(int.Parse(input[1]));
                        stack.Push(int.Parse(input[2]));
                        break;

                    case "remove":
                        int n = int.Parse(input[1]);

                        if (stack.Count >= n)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;

                    case "end":
                        Console.WriteLine($"Sum: {stack.Sum()}");
                        return;
                }
            }
        }
    }
}
