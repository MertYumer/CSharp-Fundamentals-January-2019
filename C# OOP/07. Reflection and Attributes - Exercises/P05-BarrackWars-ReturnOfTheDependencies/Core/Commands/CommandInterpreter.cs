namespace BarracksWars.Core.Commands
{
    using BarrackWars.CustomAttributes;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().First(t => t.Name.ToLower() == commandName + "command");

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes
                .Any(a => a.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] fields = fieldsToInject
                .Select(f => this.serviceProvider
                .GetService(f.FieldType))
                .ToArray();

            object[] arguments = new object[] { data }.Concat(fields).ToArray();

            IExecutable command = (IExecutable)Activator
                .CreateInstance(commandType, arguments);

            return command;
        }
    }
}
