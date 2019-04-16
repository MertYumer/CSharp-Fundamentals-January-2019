namespace P02_KingsGambit.Models
{
    using System;

    public class Footman : Warrior
    {
        public Footman(string name)
            : base(name)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
