namespace P07_InfernoInfinity.Core.Factories
{
    using System;

    using Contracts;
    using Models.Enums;

    public class GemFactory
    {
        public static IGem CreateGem(string clarity, string gemType)
        {
            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);
            Type classType = Type.GetType("P07_InfernoInfinity.Models.Gems." + gemType);
            var instance = (IGem)Activator.CreateInstance(classType, gemClarity);
            return instance;
        }
    }
}
