namespace MuOnline.Models.Heroes
{
    public class SoulMaster : Hero
    {
        private const int strength = 30;
        private const int agility = 70;
        private const int stamina = 50;
        private const int energy = 80;

        public SoulMaster(string username) 
            : base(username, strength, agility, stamina, energy)
        {
        }
    }
}
