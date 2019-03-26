namespace P07_InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Knife : Weapon
    {
        private const int BaseMinDamage = 3;
        private const int BaseMaxDamage = 4;
        private const int Sockets = 2;

        public Knife(WeaponRarity weaponRarity, string name)
            : base(weaponRarity, name, BaseMinDamage, BaseMaxDamage, Sockets)
        {
        }
    }
}
