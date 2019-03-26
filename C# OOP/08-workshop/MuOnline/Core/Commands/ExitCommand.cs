namespace MuOnline.Core.Commands
{
    using System;
    using System.Threading;

    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Exit after {i}s");
                Thread.Sleep(1000);
                Console.Clear();
            }

            Environment.Exit(0);
            return null;
        }
    }
}
