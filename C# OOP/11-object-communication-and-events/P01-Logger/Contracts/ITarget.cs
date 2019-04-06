namespace Heroes.Contracts
{
    public interface ITarget
    {
        void ReceiveDamage(int damage);

        bool IsDead { get; }
    }
}
