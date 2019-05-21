namespace P05_FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FashionBoutique
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var clothes = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRack = 0;
            int racksCount = 1;
            int n = clothes.Count;

            for (int i = 0; i < n; i++)
            {
                if (currentRack + clothes.Peek() < rackCapacity)
                {
                    currentRack += clothes.Pop();
                }

                else if (currentRack + clothes.Peek() == rackCapacity && 
                    clothes.Count >= 2)
                {
                    currentRack += clothes.Pop();
                    racksCount++;
                    currentRack = 0;
                }

                else if (currentRack + clothes.Peek() > rackCapacity)
                {
                    racksCount++;
                    currentRack = 0;
                    currentRack += clothes.Pop();
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
