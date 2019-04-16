namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        void AddGem(IGem gem, int index);

        void RemoveGem(int index);

        string ToString();
    }
}
