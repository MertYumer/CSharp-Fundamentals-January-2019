namespace P02_PointInRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            if (point.X >= TopLeft.X && point.X <= BottomRight.X 
                && point.Y >= TopLeft.Y && point.Y <= BottomRight.Y)
            {
                return true;
            }
            return false;
        }
    }
}
