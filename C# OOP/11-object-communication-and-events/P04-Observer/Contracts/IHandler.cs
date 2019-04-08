namespace Heroes.Contracts
{
    using Heroes.Enums;

    public interface IHandler
    {
        void Handle(LogType type, string message);

        void SetSuccessor(IHandler handler);
    }
}
