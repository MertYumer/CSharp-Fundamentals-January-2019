namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Items.Contracts;

    public class ItemFactory : IItemFactory
    {
        public IItem Create(string itemType)
        {
            var itemName = itemType.ToLower();

            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == itemName);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid item type!");
            }

            var item = (IItem)Activator.CreateInstance(type);
            return item;
        }
    }
}
