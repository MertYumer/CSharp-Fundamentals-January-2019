namespace P03_AnimalFarm
{
    using System;
    using P03_AnimalFarm.Models;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age})" +
                    $" can produce {chicken.ProductPerDay} eggs per day.");
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
