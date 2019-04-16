namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 50;
        private const int energyPoints = 10;
        private const int staminaPoints = 90;

        public BuffArmor()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
