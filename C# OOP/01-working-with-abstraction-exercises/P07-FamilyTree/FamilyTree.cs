namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyTree
    {
        public static void Main()
        {
            var people = new List<Person>();
            var pairs = new List<string>();

            string searchedPerson = Console.ReadLine();

            while (true)
            {
                string pair = Console.ReadLine();
                var input = pair
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 2)
                {
                    pairs.Add(pair);
                }

                else
                {
                    var personInfo = input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0] + " " + personInfo[1];
                    string birthday = personInfo[2];
                    var currentPerson = new Person(name, birthday);
                    people.Add(currentPerson);
                }
            }

            foreach (var pair in pairs)
            {
                var splittedPair = pair
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                AddParentAndChild(splittedPair, people);
            }

            var person = people
                .First(p => p.Name == searchedPerson
                || p.Birthday == searchedPerson);

            Console.WriteLine(string.Join(Environment.NewLine, person));
        }

        public static void AddParentAndChild(string[] splittedPair, List<Person> people)
        {
            string parentInfo = splittedPair[0];
            string childInfo = splittedPair[1];

            int parentIndex = people
                .FindIndex(p => p.Name == parentInfo
                || p.Birthday == parentInfo);

            int childIndex = people
                .FindIndex(p => p.Name == childInfo
                || p.Birthday == childInfo);

            var parent = new Person(people[parentIndex].Name,
                people[parentIndex].Birthday);

            var child = new Person(people[childIndex].Name,
                people[childIndex].Birthday);

            if (!people[parentIndex].Children.Any(c => c.Name == child.Name))
            {
                people[parentIndex].Children.Add(child);
            }

            if (!people[childIndex].Parents.Any(p => p.Name == parent.Name))
            {
                people[childIndex].Parents.Add(parent);
            }
        }
    }
}
