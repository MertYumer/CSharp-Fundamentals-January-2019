namespace Heroes.Commands
{
    using Heroes.Contracts;

    public class CommandExecutor : IExecutor
    {
        public void Execute(ICommand command)
        {
            command.Execute();
        }
    }
}
