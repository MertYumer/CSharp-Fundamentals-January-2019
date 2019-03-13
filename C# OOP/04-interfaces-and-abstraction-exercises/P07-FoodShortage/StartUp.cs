namespace P07_FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<IBuyer>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];
                    people.Add(new Citizen(name, age, id, birthdate));
                }

                else if (input.Length == 3)
                {
                    string group = input[2];
                    people.Add(new Rebel(name, age, group));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    int allFood = people.Sum(p => p.Food);
                    Console.WriteLine(allFood);
                    break;
                }

                var person = people.FirstOrDefault(p => p.Name == input);

                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }
    }
}
