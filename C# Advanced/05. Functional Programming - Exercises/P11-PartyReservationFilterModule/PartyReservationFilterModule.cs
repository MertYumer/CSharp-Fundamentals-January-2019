namespace P11_PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split().ToList();
            var commands = new List<string>();
            Predicate<string> predicate;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Print")
                {
                    break;
                }

                var splittedCommand = command.Split();

                if (splittedCommand[0] == "Remove")
                {
                    string secondPart = command.Substring(6, command.Length - 6);

                    int commandIndex = commands.FindIndex(x => x.EndsWith(secondPart));

                    commands.RemoveAt(commandIndex);
                }

                else
                {
                    commands.Add(command);
                }
            }

            foreach (var command in commands)
            {
                var splittedCommand = command.Split(';');
                var filterCommand = splittedCommand[1];
                var criterion = splittedCommand[2];

                predicate = GetPredicate(filterCommand, criterion);
                people.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", people));
        }

        public static Predicate<string> GetPredicate(string filterCommand, string criterion)
        {
            switch (filterCommand)
            {
                case "Starts with":
                    return p => p.StartsWith(criterion);

                case "Ends with":
                    return p => p.EndsWith(criterion);

                case "Contains":
                    return p => p.Contains(criterion);

                case "Length":
                    return p => p.Length == int.Parse(criterion);
            }

            return null;
        }
    }
}
