namespace P06_GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class GenericCountMethodDouble
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            double givenElement = double.Parse(Console.ReadLine());


            var box = new Box<double>(list);
            Console.WriteLine(box.GetGreaterElement(givenElement));
        }
    }
}
