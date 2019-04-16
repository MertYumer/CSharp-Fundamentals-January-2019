namespace P03_Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new CustomStack<int>();

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(new[] { ' ', ',' }
                    , StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Push":
                        var elements = command
                            .Skip(1)
                            .Select(int.Parse)
                            .ToList();

                        stack.Push(elements);
                        break;

                    case "Pop":
                        stack.Pop();
                        break;

                    case "END":
                        for (int i = 0; i < 2; i++)
                        {
                            foreach (var element in stack)
                            {
                                Console.WriteLine(element);
                            }
                        }

                        return;
                }
            }
        }
    }
}
