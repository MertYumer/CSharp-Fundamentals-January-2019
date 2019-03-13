namespace P08_MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {this.Corps}");
            builder.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                builder.AppendLine(mission.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
