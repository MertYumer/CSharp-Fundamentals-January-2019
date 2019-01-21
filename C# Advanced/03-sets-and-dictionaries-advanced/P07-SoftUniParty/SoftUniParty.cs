namespace P07_SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class SoftUniParty
    {
        public static void Main()
        {
            var regularGuests = new HashSet<string>();
            var vipGuests = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }

                var matchedVipGuest = Regex.Match(input, @"^[\d]\w+$");

                if (matchedVipGuest.Success)
                {
                    vipGuests.Add(input);
                }

                else
                {
                    regularGuests.Add(input);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    Console.WriteLine(vipGuests.Count + regularGuests.Count);

                    foreach (var guest in vipGuests)
                    {
                        Console.WriteLine(guest);
                    }

                    foreach (var guest in regularGuests)
                    {
                        Console.WriteLine(guest);
                    }

                    break;
                }

                vipGuests.Remove(input);
                regularGuests.Remove(input);
            }
        }
    }
}
