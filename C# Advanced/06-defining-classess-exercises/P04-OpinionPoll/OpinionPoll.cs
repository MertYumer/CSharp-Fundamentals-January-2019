namespace P04_OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OpinionPoll
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                var member = new Person(name, age);
                people.Add(member);
            }

            var olderPeople = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var person in olderPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
