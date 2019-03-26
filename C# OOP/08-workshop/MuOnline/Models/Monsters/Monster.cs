namespace MuOnline.Models.Monsters
{
    using System;

    using Contracts;

    public class Monster : IMonster
    {
        private int attackPoints;
        private int defensePoints;

        public Monster(int attackPoints, int defensePoints)
        {
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            private set
            {
                this.defensePoints = value;
            }
        }

        public bool IsAlive
            => this.DefensePoints > 0;

        public int TakeDamage(int attackPoints)
        {
            if (!this.IsAlive)
            {
                return 0;
            }

            var exp = Math.Abs(this.DefensePoints - attackPoints);
            this.DefensePoints -= attackPoints;

            return exp;
        }
    }
}
