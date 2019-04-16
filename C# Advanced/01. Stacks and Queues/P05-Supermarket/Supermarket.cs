namespace P05_Supermarket
{
    using System;
    using System.Collections.Generic;

    public class Supermarket
    {
        public static void Main()
        {
            var queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "End":
                        Console.WriteLine($"{queue.Count} people remaining.");
                        return;

                    case "Paid":
                        int n = queue.Count;

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(queue.Dequeue());
                        }

                        break;

                    default:
                        queue.Enqueue(input);
                        break;
                }
            }
        }
    }
}
