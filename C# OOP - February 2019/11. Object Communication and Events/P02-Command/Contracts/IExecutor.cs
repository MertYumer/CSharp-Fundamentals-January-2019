namespace Heroes.Contracts
{
    public interface IExecutor
    {
        void Execute(ICommand command);
    }
}
