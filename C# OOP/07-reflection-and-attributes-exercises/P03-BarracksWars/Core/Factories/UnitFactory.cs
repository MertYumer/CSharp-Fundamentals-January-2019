namespace P03_BarracksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //Type classType = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            //return (IUnit)Activator.CreateInstance(classType);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(t => t.Name == unitType);
            IUnit instance = (IUnit)Activator.CreateInstance(type);
            return instance;
        }
    }
}
