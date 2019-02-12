namespace P08_PetClinic
{
    using System;
    using System.Linq;

    public class Clinic
    {
        public Clinic(string name, int rooms)
        {
            if (rooms % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.Name = name;
            this.rooms = new Pet[rooms];
            this.midIndex = rooms / 2;
        }

        public string Name { get; set; }
        private Pet[] rooms;
        private int midIndex;

        public bool Add(Pet pet)
        {
            for (int i = 0; i <= midIndex; i++)
            {
                if (this.rooms[midIndex - i] == null)
                {
                    this.rooms[midIndex - i] = pet;
                    return true;
                }

                if (this.rooms[midIndex + i] == null)
                {
                    this.rooms[midIndex + i] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int i = midIndex; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < midIndex; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.rooms.Any(r => r == null);
        }

        public void Print()
        {
            foreach (var pet in this.rooms)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }

                else
                {
                    Console.WriteLine(pet);
                }
            }
        }

        public void PrintRoomInfo(int index)
        {
            Pet pet = this.rooms[index];

            if (pet == null)
            {
                Console.WriteLine("Room empty");
            }

            else
            {
                Console.WriteLine(pet);
            }
        }
    }
}
