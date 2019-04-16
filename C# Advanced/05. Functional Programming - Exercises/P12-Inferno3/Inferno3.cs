namespace P12_Inferno3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inferno3
    {
        public static void Main()
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            gems.Insert(0, 0);
            gems.Add(0);

            var commands = new List<string>();
            Predicate<int> predicate;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Forge")
                {
                    break;
                }

                var splittedCommand = command.Split(';');

                if (splittedCommand[0] == "Reverse")
                {
                    string secondPart = command.Substring(7, command.Length - 7);

                    int commandIndex = commands.FindIndex(x => x.EndsWith(secondPart));

                    if (commandIndex > -1)
                    {
                        commands.RemoveAt(commandIndex);
                    }
                }

                else
                {
                    commands.Add(command);
                }
            }

            for (int i = commands.Count - 1; i >= 0; i--)
            {
                var splittedCommand = commands[i].Split(';');
                string filterCommand = splittedCommand[1];
                int criterion = int.Parse(splittedCommand[2]);
                predicate = GetPredicate(gems, filterCommand, criterion);

                for (int j = gems.Count - 2; j > 0; j--)
                {
                    if (predicate(j))
                    {
                        gems.RemoveAt(j);
                    }
                }
            }

            gems.RemoveAt(gems.Count - 1);
            gems.RemoveAt(0);

            Console.WriteLine(string.Join(" ", gems));
        }

        public static Predicate<int> GetPredicate(List<int> gems, string filterCommand, int criterion)
        {
            switch (filterCommand)
            {
                case "Sum Left":
                    return i => gems[i - 1] + gems[i] == criterion;

                case "Sum Right":
                    return i => gems[i] + gems[i + 1] == criterion;

                case "Sum Left Right":
                    return i => gems[i - 1] + gems[i] + gems[i + 1] == criterion;
            }

            return null;
        }
    }
}
