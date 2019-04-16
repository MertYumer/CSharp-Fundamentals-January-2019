namespace P01_Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
