namespace P02_KingsGambit
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string kingsName = Console.ReadLine();
            var king = new King(kingsName);

            var royalGuardsNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var footmenNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var warriors = new List<Warrior>();

            foreach (var name in royalGuardsNames)
            {
                var guard = new RoyalGuard(name);
                warriors.Add(guard);
                king.IsAttacked += guard.RespondToAttack;
            }

            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                warriors.Add(footman);
                king.IsAttacked += footman.RespondToAttack;
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                switch (command)
                {
                    case "Kill":
                        string name = input[1];
                        var warrior = warriors.First(s => s.Name == name);
                        warriors.Remove(warrior);
                        king.IsAttacked -= warrior.RespondToAttack;
                        break;

                    case "Attack":
                        king.RespondToAttack();
                        break;

                    case "End":
                        return;
                }
            }
        }
    }
}
