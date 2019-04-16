﻿namespace P05_RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    public class RecordUniqueNames
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
