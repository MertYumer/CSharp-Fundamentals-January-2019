namespace P02_Animals
{
    using System.Text;

    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood)
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ExplainSelf().ToString());
            builder.Append("MEEOW");
            return builder.ToString();
        }
    }
}
