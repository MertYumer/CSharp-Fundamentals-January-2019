namespace P06_FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;

        public Player(string name, int stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public int Stats { get; private set; }
    }
}
