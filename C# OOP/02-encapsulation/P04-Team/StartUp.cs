namespace P04_Team
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Team team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                var person = new Person(
                    input[0],
                    input[1],
                    int.Parse(input[2]),
                    decimal.Parse(input[3]));

                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
