namespace P04_FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FastFood
    {
        public static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            int n = queue.Count;

            for (int i = 0; i < n; i++)
            {
                if (foodQuantity - queue.Peek() >= 0)
                {
                    foodQuantity -= queue.Dequeue();
                }

                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }

            else
            {
                Console.Write($"Orders left: ");
                Console.WriteLine(string.Join(" ", queue));
            }
        }
    }
}
