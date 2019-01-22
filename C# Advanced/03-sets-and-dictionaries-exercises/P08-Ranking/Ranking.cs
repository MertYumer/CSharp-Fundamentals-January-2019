namespace P08_Ranking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Ranking
    {
        public static void Main()
        {
            var contestsAndPasswords = new Dictionary<string, string>();
            var participants = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine().Split(':');

                if (input[0] == "end of contests")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];

                contestsAndPasswords.Add(contest, password);
            }

            while (true)
            {
                var input = Console.ReadLine().Split("=>");

                if (input[0] == "end of submissions")
                {
                    var bestCandidate = participants
                        .OrderByDescending(p => p.Value.Values.Sum())
                        .FirstOrDefault();

                    Console.WriteLine($"Best candidate is {bestCandidate.Key}" +
                        $" with total {bestCandidate.Value.Values.Sum()} points.");

                    var orderedParticipants = participants
                        .OrderBy(p => p.Key);

                    Console.WriteLine("Ranking:");

                    foreach (var person in orderedParticipants)
                    {
                        Console.WriteLine($"{person.Key}");

                        var orderedContests = person.Value.OrderByDescending(p => p.Value);

                        foreach (var currentContest in orderedContests)
                        {
                            Console.WriteLine($"#  {currentContest.Key} -> {currentContest.Value}");
                        }
                    }

                    break;
                }

                string contest = input[0];
                string password = input[1];
                string participant = input[2];
                int points = int.Parse(input[3]);

                if (contestsAndPasswords.ContainsKey(contest) &&
                    contestsAndPasswords[contest] == password)
                {
                    if (!participants.ContainsKey(participant))
                    {
                        participants.Add(participant, new Dictionary<string, int>());
                    }

                    if (!participants[participant].ContainsKey(contest))
                    {
                        participants[participant].Add(contest, points);
                    }

                    else if (participants[participant][contest] < points)
                    {
                        participants[participant][contest] = points;
                    }
                }
            }
        }
    }
}
