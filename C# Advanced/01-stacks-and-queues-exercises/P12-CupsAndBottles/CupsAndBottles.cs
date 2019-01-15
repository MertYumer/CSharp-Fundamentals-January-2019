namespace P12_CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CupsAndBottles
    {
        public static void Main()
        {
            var cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cups = new Stack<int>(cupsInput.Reverse());

            var bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottles = new Queue<int>(bottlesInput.Reverse());

            int wastedLitters = 0;

            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.WriteLine("Bottles: " + string.Join(" ", bottles));
                    Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                    break;
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine("Cups: " + string.Join(" ", cups));
                    Console.WriteLine($"Wasted litters of water: {wastedLitters}");
                    break;
                }

                if (cups.Peek() > bottles.Peek())
                {
                    int currentCup = cups.Pop();
                    currentCup -= bottles.Dequeue();

                    if (currentCup > 0)
                    {
                        cups.Push(currentCup);
                    }
                }

                else
                {
                    wastedLitters += (bottles.Dequeue() - cups.Pop());
                }
            }
        }
    }
}
