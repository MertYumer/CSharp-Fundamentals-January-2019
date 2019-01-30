namespace P10_PredicateParty
{
    using System;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split().ToList();
            Predicate<string> predicate;

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "Party!")
                {
                    if (people.Count > 0)
                    {
                        Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
                    }

                    else
                    {
                        Console.WriteLine("Nobody is going to the party!");
                    }

                    break;
                }

                string command = input[0];
                string filterCommand = input[1];
                string criterion = input[2];

                predicate = GetPredicate(filterCommand, criterion);

                switch (command)
                {
                    case "Remove":
                        people.RemoveAll(predicate);
                        break;

                    case "Double":
                        var peopleToAdd = people.FindAll(predicate);

                        foreach (var person in peopleToAdd)
                        {
                            int index = people.IndexOf(person);
                            people.Insert(index + 1, person);
                        }

                        break;
                }
            }
        }

        public static Predicate<string> GetPredicate(string filterCommand, string criterion)
        {
            switch (filterCommand)
            {
                case "StartsWith":
                    return p => p.StartsWith(criterion);

                case "EndsWith":
                    return p => p.EndsWith(criterion);

                case "Length":
                    return p => p.Length == int.Parse(criterion);
            }

            return null;
        }
    }
}
