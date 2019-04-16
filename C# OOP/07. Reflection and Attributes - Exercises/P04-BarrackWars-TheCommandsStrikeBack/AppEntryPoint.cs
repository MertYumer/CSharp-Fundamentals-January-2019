namespace BarracksWars
{
    using BarracksWars.Core.Commands;
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
