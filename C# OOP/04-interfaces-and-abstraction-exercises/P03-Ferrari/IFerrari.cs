namespace P03_Ferrari
{
    public interface IFerrari
    {
        string Model { get; }
        string Driver { get; }

        string UseBrakes();
        string PushGasPedal();
    }
}
