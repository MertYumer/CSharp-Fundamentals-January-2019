namespace P02_KingsGambit.Models
{
    using System;

    public class RoyalGuard : Warrior
    {
        public RoyalGuard(string name)
            : base(name)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
