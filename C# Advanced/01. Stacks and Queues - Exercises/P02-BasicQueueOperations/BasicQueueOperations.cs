namespace P02_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < commands[0]; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < commands[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }

            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
