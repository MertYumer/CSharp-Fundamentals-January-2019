namespace MuOnline.Core.Commands
{
    using Contracts;
    using Factories.Contracts;
    using Repositories.Contracts;
    using Models.Monsters.Contracts;

    public class AddMonsterCommand : ICommand
    {
        private const string SuccessfulMessage = "Successfully created monster: {0}";

        private readonly IRepository<IMonster> monsterRepository;
        private readonly IMonsterFactory monsterFactory;

        public AddMonsterCommand(IRepository<IMonster> monsterRepository, IMonsterFactory monsterFactory)
        {
            this.monsterRepository = monsterRepository;
            this.monsterFactory = monsterFactory;
        }

        public string Execute(string[] inputArgs)
        {
            string monsterType = inputArgs[0];

            var monster = this.monsterFactory.Create(monsterType);

            this.monsterRepository.Add(monster);

            return string.Format(SuccessfulMessage, monster.GetType().Name);
        }
    }
}
