namespace P01_ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArray
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            PrintInReversedOrder(array, array.Length - 1);
        }

        public static void PrintInReversedOrder(int[] array, int index)
        {
            if (index < 0)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(array[index] + " ");
            PrintInReversedOrder(array, index - 1);
        }
    }
}
