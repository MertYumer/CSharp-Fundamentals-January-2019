namespace P06_FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine().Split(';');

                if (input[0] == "END")
                {
                    break;
                }

                try
                {
                    string teamName = input[1];

                    if (input[0] == "Team")
                    {
                        var team = new Team(teamName);
                        teams.Add(team);
                    }

                    var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                    if (currentTeam == null)
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }

                    else if (input[0] == "Add")
                    {
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);
                        var stats = new Statistics(endurance, sprint, dribble, passing, shooting);
                        var player = new Player(playerName, stats.Stats);
                        currentTeam.AddPlayer(player);
                    }

                    else if (input[0] == "Remove")
                    {
                        string playerName = input[2];
                        currentTeam.RemovePlayer(playerName);
                    }

                    else if (input[0] == "Rating")
                    {
                        currentTeam.Rating();
                    }
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}

