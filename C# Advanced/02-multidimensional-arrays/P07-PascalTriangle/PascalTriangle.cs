namespace P07_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[n][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][i] = 1;
            }

            for (int row = 2; row < jaggedArray.Length; row++)
            {
                for (int col = 1; col < jaggedArray[row].Length - 1; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}