namespace P09_CollectionHierarchy.Models
{
    using P09_CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    public abstract class Collection : IAdd
    {
        private List<string> list;

        public Collection()
        {
            this.List = new List<string>();
        }

        protected List<string> List { get; }

        public abstract int Add(string item);
    }
}
