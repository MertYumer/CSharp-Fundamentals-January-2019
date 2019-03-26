namespace MuOnline
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    using Core;
    using Core.Contracts;
    using Models.Heroes.HeroContracts;
    using Models.Monsters.Contracts;
    using Models.Items.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Core.Factories.Contracts;
    using Core.Factories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IHeroFactory, HeroFactory>();
            serviceCollection.AddTransient<IMonsterFactory, MonsterFactory>();
            serviceCollection.AddTransient<IItemFactory, ItemFactory>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddScoped<IRepository<IHero>, HeroRepository>();
            serviceCollection.AddScoped<IRepository<IMonster>, MonsterRepository>();
            serviceCollection.AddScoped<IRepository<IItem>, ItemRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
