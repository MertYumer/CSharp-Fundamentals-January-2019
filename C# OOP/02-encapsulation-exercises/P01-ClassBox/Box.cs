namespace P01_ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public string FindSurfaceArea()
        {
            double surfaceArea = (2 * this.length * this.height)
                + (2 * this.height * this.width)
                + (2 * this.length * this.width);

            return $"Surface Area - {surfaceArea:f2}";
        }

        public string FindLateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.length * this.height)
                + (2 * this.height * this.width);

            return $"Lateral Surface Area - {lateralSurfaceArea:f2}";
        }

        public string FindVolume()
        {
            double volume = this.length * this.width * this.height;

            return $"Volume - {volume:f2}";
        }
    }
}
