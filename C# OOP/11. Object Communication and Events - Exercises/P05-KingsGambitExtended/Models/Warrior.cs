namespace P05_KingsGambitExtended.Models
{
    public delegate void WarriorDiedHandler(Warrior warior);

    public abstract class Warrior
    {
        public Warrior(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }
        
        public string Name { get; private set; }

        public int Health { get; private set; }

        public event WarriorDiedHandler WarriorDied;

        public void TakeAttack()
        {
            this.Health -= 1;

            if (this.Health == 0)
            {
                WarriorDied?.Invoke(this);
            }
        }

        public abstract void RespondToAttack();
    }
}
