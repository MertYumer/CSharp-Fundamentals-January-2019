namespace P06_Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    foreach (var animal in animals)
                    {
                        Console.WriteLine(animal);
                    }

                    break;
                }

                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];

                try
                {
                    switch (animalType)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;

                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;

                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;

                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;

                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
