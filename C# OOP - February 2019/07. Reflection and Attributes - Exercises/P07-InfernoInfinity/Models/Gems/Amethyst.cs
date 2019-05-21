namespace P07_InfernoInfinity.Models.Gems
{
    using Enums;

    public class Amethyst : Gem
    {
        private const int BaseStrength = 2;
        private const int BaseAgility = 8;
        private const int BaseVitality = 4;

        public Amethyst(GemClarity gemClarity) 
            : base(gemClarity, BaseStrength, BaseAgility, BaseVitality)
        {
        }
    }
}
