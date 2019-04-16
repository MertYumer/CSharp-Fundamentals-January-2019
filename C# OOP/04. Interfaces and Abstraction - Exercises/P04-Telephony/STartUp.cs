namespace P04_Telephony
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
