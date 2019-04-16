namespace P07_InfernoInfinity.Core.Commands
{
    using Contracts;
    using Factories;

    public class AddCommand : Command
    {
        public AddCommand(IRepository repository, string[] data)
            : base(repository, data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);
            string clarity = this.Data[3].Split()[0];
            string gemType = this.Data[3].Split()[1];

            IWeapon weapon = this.Repository.Weapons.Find(x => x.Name == weaponName);
            IGem gem = GemFactory.CreateGem(clarity, gemType);
            weapon.AddGem(gem, socketIndex);
        }
    }
}
