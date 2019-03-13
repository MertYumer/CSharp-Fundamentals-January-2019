namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
