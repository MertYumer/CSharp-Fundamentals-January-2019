namespace P07_InfernoInfinity.Core
{
    using System;

    using Contracts;

    public class Engine
    {
        public void Run(IRepository weaponRepository)
        {
            while (true)
            {
                string[] data = Console.ReadLine().Split(';');
                var commandInterpreter = new CommandInterpreter();
                commandInterpreter.InterpretCommand(weaponRepository, data);
            }
        }
    }
}
