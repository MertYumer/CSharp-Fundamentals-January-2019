namespace P05_KingsGambitExtended
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

            foreach (var name in royalGuardsNames)
            {
                var guard = new RoyalGuard(name);
                king.AddWarrior(guard);
            }

            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                king.AddWarrior(footman);
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                switch (command)
                {
                    case "Kill":
                        string name = input[1];
                        var warrior = king.Warriors.FirstOrDefault(s => s.Name == name);
                        warrior.TakeAttack();
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
