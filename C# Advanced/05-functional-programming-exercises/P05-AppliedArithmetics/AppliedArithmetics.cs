namespace P05_AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x - 1).ToArray();
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n)); 

            while (true)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;

                    case "multiply":
                        numbers = multiply(numbers);
                        break;

                    case "subtract":
                        numbers = subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;

                    case "end":
                        return;
                }
            }
        }
    }
}
