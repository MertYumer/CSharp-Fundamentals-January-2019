namespace P05_KingsGambitExtended.Models
{
    using System;

    public class RoyalGuard : Warrior
    {
        private const int Health = 3;

        public RoyalGuard(string name)
            : base(name, Health)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
