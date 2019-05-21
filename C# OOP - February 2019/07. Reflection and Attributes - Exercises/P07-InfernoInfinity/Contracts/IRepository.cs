namespace P07_InfernoInfinity.Contracts
{
    using System.Collections.Generic;

    public interface IRepository
    {
        List<IWeapon> Weapons { get; }

        void AddWeapon(IWeapon weapon);
    }
}
