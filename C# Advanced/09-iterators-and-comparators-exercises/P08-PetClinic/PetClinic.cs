namespace P08_PetClinic
{
    using System;
    using System.Collections.Generic;

    public class PetClinic
    {
        public static void Main()
        {
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "Create":
                        if (input[1] == "Pet")
                        {
                            string name = input[2];
                            int age = int.Parse(input[3]);
                            string kind = input[4];
                            var pet = new Pet(name, age, kind);
                            pets.Add(pet);
                        }

                        else if (input[1] == "Clinic")
                        {
                            string name = input[2];
                            int rooms = int.Parse(input[3]);

                            try
                            {
                                var clinic = new Clinic(name, rooms);
                                clinics.Add(clinic);
                            }
                            catch (InvalidOperationException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }

                        break;

                    case "Add":
                        string petName = input[1];
                        string clinicName = input[2];
                        int petIndex = pets.FindIndex(p => p.Name == petName);
                        int clinicIndex = clinics.FindIndex(c => c.Name == clinicName);
                        Console.WriteLine(clinics[clinicIndex].Add(pets[petIndex]));
                        break;

                    case "Release":
                    case "HasEmptyRooms":
                    case "Print":
                        clinicName = input[1];
                        clinicIndex = clinics.FindIndex(c => c.Name == clinicName);

                        if (input[0] == "Release")
                        {
                            Console.WriteLine(clinics[clinicIndex].Release());
                        }

                        else if (input[0] == "HasEmptyRooms")
                        {
                            Console.WriteLine(clinics[clinicIndex].HasEmptyRooms());
                        }

                        else if (input[0] == "Print")
                        {
                            if (input.Length == 2)
                            {
                                clinics[clinicIndex].Print();
                            }

                            else
                            {
                                int roomIndex = int.Parse(input[2]) - 1;
                                clinics[clinicIndex].PrintRoomInfo(roomIndex);
                            }
                        }

                        break;
                }
            }
        }
    }
}
