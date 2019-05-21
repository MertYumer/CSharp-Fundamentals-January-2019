namespace P02_Animals
{
    using System.Text;

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ExplainSelf().ToString());
            builder.Append("DJAAF");
            return builder.ToString();
        }
    }
}
