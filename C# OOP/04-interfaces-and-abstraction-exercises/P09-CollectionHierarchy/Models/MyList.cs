namespace P09_CollectionHierarchy.Models
{
    using P09_CollectionHierarchy.Contracts;

    public class MyList : Collection, IRemove, IUsed
    {
        public MyList()
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
            string item = this.List[0];
            this.List.RemoveAt(0);
            return item;
        }

        public int Used()
        {
            return this.List.Count;
        }
    }
}
