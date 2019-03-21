namespace BarracksWars.Core.Commands
{
    using BarrackWars.CustomAttributes;
    using Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
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
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
