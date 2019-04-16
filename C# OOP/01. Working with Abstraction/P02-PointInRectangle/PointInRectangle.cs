namespace P02_PointInRectangle
{
    using System;
    using System.Linq;

    public class PointInRectangle
    {
        public static void Main()
        {
            var coordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var topLeft = new Point(coordinates[0], coordinates[1]);
            var bottomRight = new Point(coordinates[2], coordinates[3]);
            var rectangle = new Rectangle(topLeft, bottomRight);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                coordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                var point = new Point(coordinates[0], coordinates[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
