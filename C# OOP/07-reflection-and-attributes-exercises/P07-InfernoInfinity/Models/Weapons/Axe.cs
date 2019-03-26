namespace P07_InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Axe : Weapon
    {
        private const int BaseMinDamage = 5;
        private const int BaseMaxDamage = 10;
        private const int Sockets = 4;

        public Axe(WeaponRarity weaponRarity, string name) 
            : base(weaponRarity, name, BaseMinDamage, BaseMaxDamage, Sockets)
        {
        }
    }
}
