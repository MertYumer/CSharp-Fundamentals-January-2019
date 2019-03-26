namespace P07_InfernoInfinity.Models.Weapons
{
    using System.Linq;

    using Contracts;
    using Enums;

    public abstract class Weapon : IWeapon
    {
        private WeaponRarity weaponRarity;
        private int minDamage;
        private int maxDamage;
        private IGem[] gems;
        private int strength = 0;
        private int agility = 0;
        private int vitality = 0;

        protected Weapon(WeaponRarity weaponRarity, string name, int minDamage, int maxDamage, int sockets)
        {
            this.weaponRarity = weaponRarity;
            this.Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.gems = new IGem[sockets];
        }

        public string Name { get; private set; }

        public int MinDamage
        {
            get => (this.minDamage * (int)this.weaponRarity) +
                this.gems
                .Where(g => g != null)
                .Sum(g => (g.Strength * 2) + g.Agility);

        }

        public int MaxDamage
        {
            get => (this.maxDamage * (int)this.weaponRarity) +
                this.gems
                .Where(g => g != null)
                .Sum(g => (g.Strength * 3) + (g.Agility * 4));
        }

        public void AddGem(IGem gem, int index)
        {
            if (index >= 0 && index < this.gems.Length)
            {
                this.gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.gems.Length)
            {
                this.gems[index] = null;
            }
        }

        public override string ToString()
        {
            int strength = this.gems
                .Where(g => g != null)
                .Sum(g => g.Strength);

            int agility = this.gems
                .Where(g => g != null)
                .Sum(g => g.Agility);

            int vitality = this.gems
                .Where(g => g != null)
                .Sum(g => g.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage," +
                $" +{strength} Strength," +
                $" +{agility} Agility," +
                $" +{vitality} Vitality";
        }
    }
}
