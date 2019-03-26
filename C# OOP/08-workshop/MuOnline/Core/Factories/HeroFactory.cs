namespace MuOnline.Core.Factories
{
    using Contracts;
    using MuOnline.Models.Heroes.HeroContracts;
    using System;
    using System.Linq;
    using System.Reflection;

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
