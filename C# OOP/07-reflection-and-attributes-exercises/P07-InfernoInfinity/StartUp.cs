namespace P07_InfernoInfinity
{
    using Contracts;
    using Core;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            IRepository repository = new WeaponRepository();
            Engine engine = new Engine();
            engine.Run(repository);
        }
    }
}
