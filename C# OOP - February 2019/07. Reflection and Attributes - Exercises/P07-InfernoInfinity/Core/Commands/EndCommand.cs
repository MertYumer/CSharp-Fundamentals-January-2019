namespace P07_InfernoInfinity.Core.Commands
{
    using System;

    using Contracts;

    public class EndCommand : Command
    {
        public EndCommand(IRepository repository, string[] data) 
            : base(repository, data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
