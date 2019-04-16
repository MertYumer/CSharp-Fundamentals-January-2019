namespace P05_GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class GenericCountMethodString
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            var givenElement = Console.ReadLine();

            var box = new Box<string>(list);
            Console.WriteLine(box.GetGreaterElement(givenElement));
        }
    }
}
