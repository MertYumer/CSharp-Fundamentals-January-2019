namespace P07_InfernoInfinity.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;

    public class PrintCommand : Command
    {
        public PrintCommand(IRepository repository, string[] data) 
            : base(repository, data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);
            Console.WriteLine(weapon);
        }
    }
}
