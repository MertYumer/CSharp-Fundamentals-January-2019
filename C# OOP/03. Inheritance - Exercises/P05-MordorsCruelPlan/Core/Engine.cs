namespace P05_MordorsCruelPlan.Core
{
    using Factories;
    using Food;
    using Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private FoodFactory foodFactory = new FoodFactory();
        private MoodFactory moodFactory = new MoodFactory();
        private List<Food> foods = new List<Food>();

        public Engine()
        {
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split();

            foreach (var type in input)
            {
                Food currentFood = foodFactory.CreateFood(type);
                foods.Add(currentFood);
            }

            int points = foods.Sum(f => f.Happiness);
            Mood mood;

            if (points < - 5)
            {
                mood = moodFactory.CreateMood("angry");
            }

            else if (points >= -5 && points <= 0)
            {
                mood = moodFactory.CreateMood("sad");
            }

            else if (points >= 1 && points <= 15)
            {
                mood = moodFactory.CreateMood("happy");
            }

            else
            {
                mood = moodFactory.CreateMood("javascript");
            }

            Console.WriteLine(points);
            Console.WriteLine(mood.Name);
        }
    }
}
