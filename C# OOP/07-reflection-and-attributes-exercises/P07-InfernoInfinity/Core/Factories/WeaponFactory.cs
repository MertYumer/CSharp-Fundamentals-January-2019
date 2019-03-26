namespace P07_InfernoInfinity.Core.Factories
{
    using System;

    using Contracts;
    using Models.Enums;

    public class WeaponFactory
    {
        public static IWeapon CreateWeapon(string rarity, string weaponType, string weaponName)
        {
            WeaponRarity weaponRarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), rarity);
            Type classType = Type.GetType("P07_InfernoInfinity.Models.Weapons." + weaponType);
            var instance = (IWeapon)Activator
                .CreateInstance(classType, new object[] { weaponRarity, weaponName });

            return instance;
        }
    }
}
