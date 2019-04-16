namespace P03_GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var scale = new EqualityScale<int>(8, 10);
            Console.WriteLine(scale.AreEqual());

            var secondScale = new EqualityScale<string>("Bus", "Car");
            Console.WriteLine(secondScale.AreEqual());
        }
    }
}
