namespace P07_InfernoInfinity.Data
{
    using System.Collections.Generic;

    using Contracts;

    public class WeaponRepository : IRepository
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public List<IWeapon> Weapons => this.weapons;

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }
    }
}
