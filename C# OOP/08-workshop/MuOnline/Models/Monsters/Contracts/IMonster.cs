namespace MuOnline.Models.Monsters.Contracts
{
    public interface IMonster
    {
        int AttackPoints { get; }

        int DefensePoints { get; }

        bool IsAlive { get; }

        int TakeDamage(int attackPoints);
    }
}
