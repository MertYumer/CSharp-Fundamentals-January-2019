namespace MuOnline.Core.Commands
{
    using Contracts;
    using Models.Heroes.HeroContracts;
    using Factories.Contracts;
    using Repositories.Contracts;

    public class AddHeroCommand : ICommand
    {
        private const string SuccessfulMessage = "Successfully created hero: {0}";

        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> heroRepository, IHeroFactory heroFactory)
        {
            this.heroRepository = heroRepository;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            string heroType = inputArgs[0];
            string username = inputArgs[1];

            var hero = this.heroFactory.Create(heroType, username);

            this.heroRepository.Add(hero);

            return string.Format(SuccessfulMessage, username);
        }
    }
}
