namespace P10_ExplicitInterfaces
{
    using System;

    public class Start
    {
        public static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);
                var citizen = new Citizen(name, country, age);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
