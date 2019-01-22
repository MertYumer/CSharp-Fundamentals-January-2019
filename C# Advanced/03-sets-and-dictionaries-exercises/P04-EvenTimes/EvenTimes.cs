namespace P04_EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EvenTimes
    {
        public static void Main()
        {
            var numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            int foundNumber = numbers.FirstOrDefault(x => x.Value % 2 == 0).Key;
            Console.WriteLine(foundNumber);
        }
    }
}
