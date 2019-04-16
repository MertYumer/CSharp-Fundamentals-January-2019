namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
