namespace P03_DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Documents: ");
            builder.Append(string.Join(Environment.NewLine, this.Documents));
            return builder.ToString();
        }
    }
}
