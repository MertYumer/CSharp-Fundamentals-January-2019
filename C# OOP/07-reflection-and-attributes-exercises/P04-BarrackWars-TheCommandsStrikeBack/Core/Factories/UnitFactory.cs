namespace BarracksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(t => t.Name == unitType);
            IUnit instance = (IUnit)Activator.CreateInstance(type);
            return instance;
        }
    }
}
