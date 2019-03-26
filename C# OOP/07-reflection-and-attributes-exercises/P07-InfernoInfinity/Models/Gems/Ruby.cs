namespace P07_InfernoInfinity.Models.Gems
{
    using Enums;

    public class Ruby : Gem
    {
        private const int BaseStrength = 7;
        private const int BaseAgility = 2;
        private const int BaseVitality = 5;

        public Ruby(GemClarity gemClarity)
            : base(gemClarity, BaseStrength, BaseAgility, BaseVitality)
        {
        }
    }
}
