namespace P04_Telephony
{
    using System.Linq;

    public class Smartphone : ICaller, IBrowser
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(d => char.IsDigit(d)))
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if (url.Any(s => char.IsDigit(s)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}
