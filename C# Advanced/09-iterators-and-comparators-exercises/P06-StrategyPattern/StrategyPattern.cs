namespace P06_StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StrategyPattern
    {
        public static void Main()
        {
            var nameCopmarer = new NameComparator();
            var ageCopmarer = new AgeComparator();

            var peopleByName = new SortedSet<Person>(nameCopmarer);
            var peopleByAge = new SortedSet<Person>(ageCopmarer);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                var person = new Person(name, age);

                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            foreach (var person in peopleByName)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in peopleByAge)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
