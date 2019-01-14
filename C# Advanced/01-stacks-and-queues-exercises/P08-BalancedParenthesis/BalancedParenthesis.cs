namespace P08_BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var brackets = Console.ReadLine();
            char[] input = brackets.ToCharArray();
            var stack = new Stack<char>(input.Length);
            bool match = true;

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(input[i]);
                        break;

                    case ')':
                        if (!stack.Any())
                        {
                            match = false;
                        }

                        else if (stack.Pop() != '(')
                        {
                            match = false;
                        }
                        break;

                    case ']':
                        if (!stack.Any())
                        {
                            match = false;
                        }

                        else if (stack.Pop() != '[')
                        {
                            match = false;
                        }
                        break;

                    case '}':
                        if (!stack.Any())
                        {
                            match = false;
                        }

                        else if (stack.Pop() != '{')
                        {
                            match = false;
                        }
                        break;
                }

                if (!match)
                {
                    break;
                }
            }

            Console.WriteLine(match ? "YES" : "NO");
        }
    }
}
