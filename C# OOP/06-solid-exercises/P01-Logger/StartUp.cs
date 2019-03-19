namespace P01_Logger
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
