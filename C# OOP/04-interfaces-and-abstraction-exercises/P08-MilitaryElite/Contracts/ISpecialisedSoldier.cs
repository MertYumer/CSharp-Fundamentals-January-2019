namespace P08_MilitaryElite.Contracts
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
