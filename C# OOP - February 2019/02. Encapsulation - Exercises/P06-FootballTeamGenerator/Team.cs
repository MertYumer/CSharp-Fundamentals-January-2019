namespace P06_FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            int playerIndex = this.players.FindIndex(p => p.Name == playerName);

            if (playerIndex == -1)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.RemoveAt(playerIndex);
        }

        public void Rating()
        {
            int averageRating = this.players.Count > 0 
                ? (int)Math.Round(this.players.Average(p => p.Stats))
                : 0;
            Console.WriteLine($"{this.Name} - {averageRating}");
        }
    }
}
