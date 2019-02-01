namespace P09_RectangleIntersection
{
    using System;

    public class Rectangle
    {
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public void CheckIntersection(Rectangle secondRectangle)
        {
            if (X <= secondRectangle.X + secondRectangle.Width &&
                X + Width >= secondRectangle.X &&
                Y >= secondRectangle.Y - secondRectangle.Height &&
                Y - Height <= secondRectangle.Y)
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
