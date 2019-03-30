namespace P02_ExtendedDatabase
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;

        private Person[] data;
        private int index;

        public Database(params Person[] data)
        {
            CheckLength(data);
            this.data = new Person[16];
            this.index = 0;
            CopyArray(data);
        }

        private void CopyArray(Person[] data)
        {
            foreach (var person in data)
            {
                this.Add(person);
            }
        }

        private void CheckLength(Person[] data)
        {
            if (data.Length > 16)
            {
                throw new InvalidOperationException("The size of the " +
                    "parameter must be equal or less than 16!");
            }
        }

        public void Add(Person person)
        {
            if (this.index == Capacity)
            {
                throw new InvalidOperationException("Data is full!");
            }

            if (this.data.Any(p => p != null && p.Username == person.Username))
            {
                throw new InvalidOperationException("Person with the" +
                    " same username already exists!");
            }

            if (this.data.Any(p => p != null && p.Id == person.Id))
            {
                throw new InvalidOperationException("Person with the" +
                    " same id already exists!");
            }

            this.data[this.index] = person;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Data is empty!");
            }

            this.data[this.index] = null;
            this.index--;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be null or empty!");
            }

            if (!this.data.Any(p => p != null && p.Username == username))
            {
                throw new InvalidOperationException("Person with this " +
                    "username doesn't exist!");
            }

            return this.data.First(p => p != null && p.Username == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be less than zero!");
            }

            if (!this.data.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException("Person with this " +
                    "id doesn't exist!");
            }

            return this.data.First(p => p != null && p.Id == id);
        }

        public Person[] Fetch()
        {
            return this.data.Take(index).ToArray();
        }
    }
}
