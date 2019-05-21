namespace P05_KingsGambitExtended.Models
{
    using System;
    using System.Collections.Generic;

    public delegate void KingIsAttackedEventHandler();

    public class King
    {
        private List<Warrior> warriors;

        public King(string name)
        {
            this.Name = name;
            this.warriors = new List<Warrior>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Warrior> Warriors => this.warriors;

        public event KingIsAttackedEventHandler IsAttacked;

        public void AddWarrior(Warrior warrior)
        {
            this.warriors.Add(warrior);
            this.IsAttacked += warrior.RespondToAttack;
            warrior.WarriorDied += this.WarriorDied;
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.IsAttacked?.Invoke();
        }

        public void WarriorDied(Warrior warrior)
        {
            this.IsAttacked -= warrior.RespondToAttack;
            this.warriors.Remove(warrior);
        }
    }
}
