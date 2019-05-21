namespace P09_CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
        public AddCollection()
            : base()
        {
        }

        public override int Add(string item)
        {
            this.List.Add(item);
            int itemIndex = this.List.Count - 1;
            return itemIndex;
        }
    }
}
