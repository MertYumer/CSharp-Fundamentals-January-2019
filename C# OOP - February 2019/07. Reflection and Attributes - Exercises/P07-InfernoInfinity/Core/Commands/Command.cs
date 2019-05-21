namespace P07_InfernoInfinity.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;

        public Command(IRepository repository, string[] data)
        {
            this.repository = repository;
            this.data = data;
        }

        protected string[] Data => this.data;

        protected IRepository Repository => this.repository;

        public abstract void Execute();
    }
}
