namespace P03_GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var scale = new Scale<int>(8, 10);
            Console.WriteLine(scale.GetHeavier());

            var secondScale = new Scale<string>("Bus", "Car");
            Console.WriteLine(secondScale.GetHeavier());
        }
    }
}
