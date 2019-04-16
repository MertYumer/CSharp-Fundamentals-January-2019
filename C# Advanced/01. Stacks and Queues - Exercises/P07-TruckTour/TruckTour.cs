namespace P07_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();

            bool fullCircle = true;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(input);
            }

            for (int i = 0; i < n; i++)
            {
                int fuel = 0;

                for (int j = 0; j < n; j++)
                {
                    int[] currentPump = pumps.Dequeue();
                    fuel += (currentPump[0] - currentPump[1]);

                    if (fuel < 0)
                    {
                        fullCircle = false;
                    }

                    pumps.Enqueue(currentPump);
                }

                if (fullCircle)
                {
                    Console.WriteLine(i);
                    break;
                }

                int[] startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
                fullCircle = true;
            }
        }
    }
}