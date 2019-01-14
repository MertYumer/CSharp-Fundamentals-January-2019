namespace P09_SImpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var commands = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        commands.Push(text);
                        text += input[1];
                        break;

                    case "2":
                        commands.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(input[1]));
                        break;

                    case "3":
                        Console.WriteLine(text[int.Parse(input[1]) - 1]);
                        break;

                    case "4":
                        text = commands.Pop();
                        break;
                }
            }
        }
    }
}
