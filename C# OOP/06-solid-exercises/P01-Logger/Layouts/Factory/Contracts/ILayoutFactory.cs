namespace P01_Logger.Layouts.Factory.Contracts
{
    using Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
