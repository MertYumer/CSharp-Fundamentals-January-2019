namespace MuOnline.Core
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();
                    var result = commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }

                catch (ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
