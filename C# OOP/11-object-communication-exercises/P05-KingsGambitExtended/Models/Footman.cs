namespace P05_KingsGambitExtended.Models
{
    using System;

    public class Footman : Warrior
    {
        private const int Health = 2;

        public Footman(string name)
            : base(name, Health)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
