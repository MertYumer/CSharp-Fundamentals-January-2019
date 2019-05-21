namespace P03_Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string driver = Console.ReadLine();
            var ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
