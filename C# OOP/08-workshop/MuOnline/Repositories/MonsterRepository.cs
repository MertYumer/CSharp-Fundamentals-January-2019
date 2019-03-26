namespace MuOnline.Repositories
{
    using Contracts;
    using Models.Monsters.Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MonsterRepository : IRepository<IMonster>
    {
        private readonly List<IMonster> monsters;

        public MonsterRepository()
        {
            this.monsters = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository
            => this.monsters.AsReadOnly();

        public void Add(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            this.monsters.Add(monster);
        }

        public IMonster Get(string monster)
        {
            var targetMonster = this.monsters.FirstOrDefault(m => m.GetType().Name == monster);

            if (targetMonster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            return targetMonster;
        }

        public bool Remove(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            bool isRemoved = this.monsters.Remove(monster);
            return isRemoved;
        }
    }
}
