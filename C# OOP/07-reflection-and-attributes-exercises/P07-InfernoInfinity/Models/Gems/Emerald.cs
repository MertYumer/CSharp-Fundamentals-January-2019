namespace P07_InfernoInfinity.Models.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int BaseStrength = 1;
        private const int BaseAgility = 4;
        private const int BaseVitality = 9;

        public Emerald(GemClarity gemClarity)
            : base(gemClarity, BaseStrength, BaseAgility, BaseVitality)
        {
        }
    }
}
