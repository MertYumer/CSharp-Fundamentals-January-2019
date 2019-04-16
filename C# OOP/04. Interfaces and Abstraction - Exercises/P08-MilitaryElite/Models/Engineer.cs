namespace P08_MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                builder.AppendLine(repair.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
