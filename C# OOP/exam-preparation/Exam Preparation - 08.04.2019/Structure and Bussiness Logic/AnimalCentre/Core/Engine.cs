namespace AnimalCentre.Core
{
    using System;

    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            string type = input[1];
                            string name = input[2];
                            int energy = int.Parse(input[3]);
                            int happiness = int.Parse(input[4]);
                            int procedureTime = int.Parse(input[5]);
                            Console.WriteLine(this.animalCentre.RegisterAnimal(type, name,
                                energy, happiness, procedureTime));
                            break;

                        case "Chip":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.Chip(name, procedureTime));
                            break;

                        case "Fitness":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.Fitness(name, procedureTime));
                            break;

                        case "Play":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.Play(name, procedureTime));
                            break;

                        case "DentalCare":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.DentalCare(name, procedureTime));

                            break;

                        case "NailTrim":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.NailTrim(name, procedureTime));
                            break;

                        case "Vaccinate":
                            name = input[1];
                            procedureTime = int.Parse(input[2]);
                            Console.WriteLine(this.animalCentre.Vaccinate(name, procedureTime));
                            break;

                        case "Adopt":
                            string animalName = input[1];
                            string owner = input[2];
                            Console.WriteLine(this.animalCentre.Adopt(animalName, owner));
                            break;

                        case "History":
                            type = input[1];
                            Console.WriteLine(this.animalCentre.History(type));
                            break;

                        case "End":
                            Console.WriteLine(this.animalCentre.GetOwnersInfo());
                            return;
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }

                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }
            }
        }
    }
}
