namespace P09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            Func<int, int, bool> isNotDivisable = (x, y) => x % y != 0;
            Action<List<int>> printNumbers = x => Console.WriteLine(string.Join(" ", x));

            int number = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool validNumber = true;
            var result = new List<int>();

            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (isNotDivisable(currentNumber, numbers[i]))
                    {
                        validNumber = false;
                        break;
                    }
                }

                if (validNumber)
                {
                    result.Add(currentNumber);
                }

                validNumber = true;
            }

            printNumbers(result);
        }
    }
}
