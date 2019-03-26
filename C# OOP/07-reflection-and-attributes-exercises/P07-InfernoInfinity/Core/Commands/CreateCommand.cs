namespace P07_InfernoInfinity.Core.Commands
{
    using Contracts;
    using Factories;

    public class CreateCommand : Command
    {
        public CreateCommand(IRepository repository, string[] data) 
            : base(repository, data)
        {
        }

        public override void Execute()
        {
            string rarity = this.Data[1].Split()[0];
            string type = this.Data[1].Split()[1];
            string name = this.Data[2];

            IWeapon weapon = WeaponFactory.CreateWeapon(rarity, type, name);
            this.Repository.AddWeapon(weapon);
        }
    }
}
