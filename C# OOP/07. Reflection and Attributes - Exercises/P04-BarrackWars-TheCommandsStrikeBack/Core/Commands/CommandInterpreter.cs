namespace BarracksWars.Core.Commands
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().First(t => t.Name.ToLower() == commandName + "command");

            IExecutable command = (IExecutable)Activator
                .CreateInstance(commandType, new object[] { data, this.repository, this.unitFactory });

            return command;
        }
    }
}
