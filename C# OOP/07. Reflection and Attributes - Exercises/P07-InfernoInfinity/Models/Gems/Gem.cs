namespace P07_InfernoInfinity.Models.Gems
{
    using Contracts;
    using Enums;

    public abstract class Gem : IGem
    {
        protected Gem(GemClarity gemClarity, int strength, int agility, int vitality)
        {
            this.Strength = strength + (int)gemClarity;
            this.Agility = agility + (int)gemClarity;
            this.Vitality = vitality + (int)gemClarity;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }
    }
}
