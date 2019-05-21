﻿namespace P02_SumNumbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
