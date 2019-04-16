namespace P07_TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    Console.WriteLine($"{count} cars passed the crossroads.");
                    break;
                }

                else if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }

                else
                {
                    queue.Enqueue(command);
                }
            }
        }
    }
}
