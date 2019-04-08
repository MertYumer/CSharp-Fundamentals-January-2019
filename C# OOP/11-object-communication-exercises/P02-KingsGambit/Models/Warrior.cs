namespace P02_KingsGambit.Models
{
    public abstract class Warrior
    {
        public Warrior(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void RespondToAttack();
    }
}
