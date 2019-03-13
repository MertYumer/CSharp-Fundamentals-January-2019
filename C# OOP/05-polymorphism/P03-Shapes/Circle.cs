namespace P03_Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return radius * Math.PI * 2;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
