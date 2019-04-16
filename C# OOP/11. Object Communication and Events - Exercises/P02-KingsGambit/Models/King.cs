namespace P02_KingsGambit.Models
{
    using System;

    public delegate void KingIsAttackedEventHandler();

    public class King : Warrior
    {
        public King(string name)
            : base(name)
        {
        }

        public event KingIsAttackedEventHandler IsAttacked;

        public override void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.IsAttacked?.Invoke();
        }
    }
}
