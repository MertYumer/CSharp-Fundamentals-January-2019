namespace Heroes.Contracts
{
    public interface IAttacker
    {
        void Attack();

        void SetTarget(ITarget target);
    }
}
