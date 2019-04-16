namespace P07_TheVlogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheVlogger
    {
        public static void Main()
        {
            var vloggersAndFollowers = new Dictionary<string, SortedSet<string>>();
            var vloggersAndFollowings = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "Statistics")
                {
                    Console.WriteLine($"The V-Logger has a total of {vloggersAndFollowers.Keys.Count}" +
                        $" vloggers in its logs.");

                    var orderedVloggersAndFollowings = vloggersAndFollowings
                        .OrderByDescending(v => v.Value["followers"])
                        .ThenBy(v => v.Value["following"]);

                    int counter = 1; ;

                    foreach (var firstVlogger in orderedVloggersAndFollowings)
                    {
                        foreach (var secondVlogger in vloggersAndFollowers)
                        {
                            if (firstVlogger.Key == secondVlogger.Key)
                            {
                                Console.WriteLine($"{counter}. {firstVlogger.Key} : " +
                                    $"{firstVlogger.Value["followers"]} followers, " +
                                    $"{firstVlogger.Value["following"]} following");

                                if (counter == 1)
                                {
                                    foreach (var follower in secondVlogger.Value)
                                    {
                                        Console.WriteLine($"*  {follower}");
                                    }
                                }

                                counter++;
                            }
                        }
                    }

                    break;
                }

                string firstUser = input[0];
                string command = input[1];

                if (command == "joined" && !vloggersAndFollowers.ContainsKey(firstUser))
                {
                    vloggersAndFollowers.Add(firstUser, new SortedSet<string>());
                    vloggersAndFollowings.Add(firstUser, new Dictionary<string, int>());
                    vloggersAndFollowings[firstUser]["followers"] = 0;
                    vloggersAndFollowings[firstUser]["following"] = 0;
                    continue;
                }

                string secondUser = input[2];

                if (command == "followed" && vloggersAndFollowers.ContainsKey(firstUser) &&
                    vloggersAndFollowers.ContainsKey(secondUser) && firstUser != secondUser &&
                    !vloggersAndFollowers[secondUser].Contains(firstUser))
                {
                    vloggersAndFollowers[secondUser].Add(firstUser);
                    vloggersAndFollowings[firstUser]["following"] += 1;
                    vloggersAndFollowings[secondUser]["followers"] += 1;
                }
            }
        }
    }
}
