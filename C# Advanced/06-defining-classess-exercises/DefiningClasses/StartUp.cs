using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < input[0]; i++)
            {
                var rectangle = Console.ReadLine().Split();
                string id = rectangle[0];
                double width = double.Parse(rectangle[1]);
                double height = double.Parse(rectangle[2]);
                double x = double.Parse(rectangle[3]);
                double y = double.Parse(rectangle[4]);

                var currentRectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(currentRectangle);
            }

            for (int i = 0; i < input[1]; i++)
            {
                var pair = Console.ReadLine().Split();

                var firstRectangle = rectangles
                    .Find(r => r.Id == pair[0]);

                var secondRectangle = rectangles
                    .Find(r => r.Id == pair[1]);
                    
                firstRectangle.CheckIntersection(secondRectangle);
            }
        }
    }
}
