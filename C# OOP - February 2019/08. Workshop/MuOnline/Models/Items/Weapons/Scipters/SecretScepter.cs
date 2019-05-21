namespace MuOnline.Models.Items.Weapons.Scipters
{
    public class SecretScepter : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 10;
        private const int energyPoints = 50;
        private const int staminaPoints = 20;

        public SecretScepter() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
