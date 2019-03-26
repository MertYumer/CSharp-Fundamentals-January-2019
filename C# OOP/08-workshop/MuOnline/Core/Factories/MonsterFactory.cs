namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Monsters.Contracts;

    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterTypeName)
        {
            var monsterTypeNameLowerCase = monsterTypeName.ToLower();

            var type = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .Where(m => typeof(IMonster).IsAssignableFrom(m))
                 .FirstOrDefault(m => m.Name.ToLower() == monsterTypeNameLowerCase);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid monster type!");
            }

            var monster = (IMonster)Activator.CreateInstance(type);
            return monster;
        }
    }
}
