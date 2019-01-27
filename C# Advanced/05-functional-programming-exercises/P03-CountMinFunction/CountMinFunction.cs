namespace P03_CountMinFunction
{
    using System;
    using System.Linq;

    public class CountMinFunction
    {
        public static void Main()
        {
            Func<int[], int> minNumber = n => n.Min();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(minNumber(numbers));
        }
    }
}
