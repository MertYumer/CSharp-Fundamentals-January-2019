namespace P05_LongestIncreasingSubsequence_LIS_
{
    using System;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var length = new int[numbers.Length];
            var previous = new int[numbers.Length];

            int maxIndex = 0;
            int maxLength = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int bestLength = 1;
                int previousIndex = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] > numbers[j] && length[j] + 1 >= bestLength)
                    {
                        bestLength = length[j] + 1;
                        previousIndex = j;
                    }
                }

                length[i] = bestLength;
                previous[i] = previousIndex;

                if (bestLength > maxLength)
                {
                    maxLength = bestLength;
                    maxIndex = i;
                }
            }

            var result = new int[maxLength];
            int index = 0;

            while (maxIndex != -1)
            {
                result[index++] = numbers[maxIndex];
                maxIndex = previous[maxIndex];
            }

            Console.WriteLine(string.Join(" ", result.Reverse()));
        }
    }
}
