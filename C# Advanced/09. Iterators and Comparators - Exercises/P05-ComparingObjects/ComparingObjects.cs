namespace P05_ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class ComparingObjects
    {
        public static void Main()
        {
            var people = new List<Person>();
            int equalPeople = 0;
            int differentPeople = 0;

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                var person = new Person(name, age, town);
                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            foreach (var person in people)
            {
                if (people[index].CompareTo(person) == 0)
                {
                    equalPeople++;
                }

                else
                {
                    differentPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
