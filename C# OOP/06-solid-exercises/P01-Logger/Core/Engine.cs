namespace P01_Logger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(input);
            }

            while (true)
            {
                var input = Console.ReadLine().Split('|');

                if (input[0] == "END")
                {
                    break;
                }

                this.commandInterpreter.AddMessage(input);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
