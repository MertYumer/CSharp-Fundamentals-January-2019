namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffBoots : Item
    {
        private const int strengthPoints = 3;
        private const int agilityPoints = 5;
        private const int energyPoints = 0;
        private const int staminaPoints = 10;

        public BuffBoots()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
