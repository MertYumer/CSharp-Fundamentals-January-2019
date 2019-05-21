﻿namespace P01_ClassBox
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(length, width, height);

            Console.WriteLine(box.FindSurfaceArea());
            Console.WriteLine(box.FindLateralSurfaceArea());
            Console.WriteLine(box.FindVolume());
        }
    }
}
