namespace Heroes.Contracts
{
    public interface ISubject
    {
        void Register(IObserver observer);

        void UnRegister(IObserver observer);

        void NotifyObservers();
    }
}
