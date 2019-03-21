namespace BarracksWars.Core.Commands
{
    using Contracts;
    using System;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }
        }
    }
}
