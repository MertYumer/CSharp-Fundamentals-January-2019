namespace BarracksWars.Core.Commands
{
    using BarrackWars.CustomAttributes;
    using Contracts;
    using System;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
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
