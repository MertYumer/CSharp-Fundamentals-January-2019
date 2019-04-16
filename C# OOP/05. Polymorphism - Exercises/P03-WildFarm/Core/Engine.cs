namespace P03_WildFarm.Core
{
    using P03_WildFarm.Animals;
    using P03_WildFarm.Factories;
    using P03_WildFarm.Foods;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public void Run()
        {
            var animals = new List<Animal>();

            while (true)
            {
                var animalInfo = Console.ReadLine().Split();

                if (animalInfo[0] == "End")
                {
                    break;
                }

                Animal animal = AnimalFactory.CreateAnimal(animalInfo);
                animals.Add(animal);

                var foodInfo = Console.ReadLine().Split();
                string type = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);
                Food food = FoodFactory.CreateFood(type, quantity);

                try
                {
                    animal.ProduceSound();
                    animal.Eat(food);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
