namespace P07_InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Sword : Weapon
    {
        private const int BaseMinDamage = 4;
        private const int BaseMaxDamage = 6;
        private const int Sockets = 3;

        public Sword(WeaponRarity weaponRarity, string name)
            : base(weaponRarity, name, BaseMinDamage, BaseMaxDamage, Sockets)
        {
        }
    }
}
