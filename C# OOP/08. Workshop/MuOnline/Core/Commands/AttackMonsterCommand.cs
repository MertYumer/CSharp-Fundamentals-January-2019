namespace MuOnline.Core.Commands
{
    using Contracts;
    using Models.Heroes.HeroContracts;
    using Models.Monsters.Contracts;
    using Repositories.Contracts;

    public class AttackMonsterCommand : ICommand
    {
        private const string commandMessage = "{0} is the winner!";

        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository,
            IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string heroUsername = inputArgs[0];
            string monsterUsername = inputArgs[1];

            var hero = this.heroRepository.Get(heroUsername);
            var monster = this.monsterRepository.Get(monsterUsername);

            var heroAttackPoints = hero.TotalAttackPoints;
            var monsterAttackPoints = monster.AttackPoints;

            while (hero.IsAlive && monster.IsAlive)
            {
                hero.TakeDamage(monsterAttackPoints);

                if (!hero.IsAlive)
                {
                    break;
                }

                var experience = monster.TakeDamage(heroAttackPoints);
                ((IProgress)hero).AddExperience(experience);
            }

            return string.Format(commandMessage, 
                hero.IsAlive 
                ? hero.GetType().Name 
                : monster.GetType().Name);
        }
    }
}
