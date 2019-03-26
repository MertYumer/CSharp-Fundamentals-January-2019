namespace P07_InfernoInfinity.Core
{
    using System;
    using System.Linq;

    using Contracts;

    public class CommandInterpreter
    {
        public void InterpretCommand(IRepository weaponRepository, string[] data)
        {
            string name = data[0];
            string commandName = name.ToUpper().First() + name.ToLower().Substring(1) + "Command";

            Type commandType = Type.GetType("P07_InfernoInfinity.Core.Commands." + commandName);
            var command = (IExecutable)Activator
                .CreateInstance(commandType, new object[] { weaponRepository, data });

            command.Execute();
        }
    }
}
