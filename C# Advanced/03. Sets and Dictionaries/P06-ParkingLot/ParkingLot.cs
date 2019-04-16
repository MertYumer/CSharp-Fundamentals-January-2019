namespace P06_ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        public static void Main()
        {
            var parking = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "END":

                        if (parking.Count == 0)
                        {
                            Console.WriteLine("Parking Lot is Empty");
                        }

                        else
                        {
                            foreach (var carNumber in parking)
                            {
                                Console.WriteLine(carNumber);
                            }
                        }

                        return;

                    case "IN":
                        parking.Add(input[1]);
                        break;

                    case "OUT":
                        parking.Remove(input[1]);
                        break;
                }
            }
        }
    }
}
