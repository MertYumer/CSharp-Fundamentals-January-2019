namespace P07_InfernoInfinity.Core.Commands
{
    using System.Linq;

    using Contracts;

    public class RemoveCommand : Command
    {
        public RemoveCommand(IRepository repository, string[] data) 
            : base(repository, data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);

            IWeapon weapon = this.Repository.Weapons.FirstOrDefault(w => w.Name == weaponName);
            weapon.RemoveGem(socketIndex);
        }
    }
}
