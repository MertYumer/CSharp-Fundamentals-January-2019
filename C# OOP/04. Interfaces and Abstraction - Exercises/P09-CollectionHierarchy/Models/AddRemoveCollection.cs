namespace P09_CollectionHierarchy.Models
{
    using P09_CollectionHierarchy.Contracts;

    public class AddRemoveCollection : Collection, IRemove
    {
        public AddRemoveCollection()
            : base()
        {
        }

        public override int Add(string item)
        {
            this.List.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string item = this.List[this.List.Count - 1];
            this.List.RemoveAt(this.List.Count - 1);
            return item;
        }
    }
}
