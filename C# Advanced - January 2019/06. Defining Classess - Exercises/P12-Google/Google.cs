namespace P12_Google
{
    using System;
    using System.Collections.Generic;

    public class Google
    {
        public static void Main()
        {
            var people = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];
                int index = people.FindIndex(p => p.Name == name);
                Person person;
                Pokemon pokemon;
                Parent parent;
                Child child;

                switch (input[1])
                {
                    case "company":
                        string companyName = input[2];
                        string department = input[3];
                        decimal salary = decimal.Parse(input[4]);
                        var company = new Company(companyName, department, salary);
                        person = new Person(name, company);

                        if (index == -1)
                        {
                            people.Add(person);
                        }

                        else
                        {
                            people[index].Company = person.Company;
                        }

                        break;

                    case "car":
                        string model = input[2];
                        int speed = int.Parse(input[3]);
                        var car = new Car(model, speed);
                        person = new Person(name, car);

                        if (index == -1)
                        {
                            people.Add(person);
                        }

                        else
                        {
                            people[index].Car = person.Car;
                        }

                        break;

                    case "pokemon":
                        string pokemonName = input[2];
                        string type = input[3];
                        pokemon = new Pokemon(pokemonName, type);
                        person = new Person(name);

                        if (index == -1)
                        {
                            people.Add(person);
                            people[people.Count - 1].Pokemons.Add(pokemon);
                        }

                        else
                        {
                            people[index].Pokemons.Add(pokemon);
                        }

                        break;

                    case "parents":
                        string parentName = input[2];
                        string parentBirthday = input[3];
                        parent = new Parent(parentName, parentBirthday);
                        person = new Person(name);

                        if (index == -1)
                        {
                            people.Add(person);
                            people[people.Count - 1].Parents.Add(parent);
                        }

                        else
                        {
                            people[index].Parents.Add(parent);
                        }

                        break;

                    case "children":
                        string childName = input[2];
                        string childBirthday = input[3];
                        child = new Child(childName, childBirthday);
                        person = new Person(name);

                        if (index == -1)
                        {
                            people.Add(person);
                            people[people.Count - 1].Children.Add(child);
                        }

                        else
                        {
                            people[index].Children.Add(child);
                        }

                        break;
                }
            }

            string personName = Console.ReadLine();
            int personIndex = people.FindIndex(p => p.Name == personName);

            Console.WriteLine(string.Join(Environment.NewLine, people[personIndex]));
        }
    }
}
