namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Heroes.HeroContracts;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroTypeName, string username)
        {
            var heroTypeNameLowerCase = heroTypeName.ToLower();

            var type = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .FirstOrDefault(h => h.Name.ToLower() == heroTypeNameLowerCase);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid hero type!");
            }

            var hero = (IHero)Activator.CreateInstance(type, username);
            return hero;
        }
    }
}
