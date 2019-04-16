namespace P03_MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        stack.Push(input[1]);
                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        
                        break;

                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

