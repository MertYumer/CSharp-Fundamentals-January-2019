namespace P02_NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        public static int[] array;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            array = new int[n];

            PrintNestedLoops(n, 0);
        }

        public static void PrintNestedLoops(int n, int counter)
        {
            if (counter >= n)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                array[counter] = i;
                PrintNestedLoops(n, counter + 1);
            }
        }
    }
}
