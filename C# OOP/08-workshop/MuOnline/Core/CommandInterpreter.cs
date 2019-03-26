namespace MuOnline.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Commands.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            string commandName = args[0].ToLower() + Suffix;
            var input = args.Skip(1).ToArray();

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var parameters = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var services = parameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var typeInstance = (ICommand)Activator.CreateInstance(type, services);
            var result = typeInstance.Execute(input);

            return result;
        }
    }
}
