namespace P04_HotelReservation
{
    using System;

    public class HotelReservation
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            decimal pricePerDay = decimal.Parse(input[0]);
            int daysCount = int.Parse(input[1]);
            Season season = Enum.Parse<Season>(input[2]);
            Discount discount = Discount.None;

            if (input.Length == 4)
            {
                discount = Enum.Parse<Discount>(input[3]);
            }

            var priceCalculator = new PriceCalculator(pricePerDay, daysCount, season, discount);
            Console.WriteLine(priceCalculator.CalculatePrice().ToString("F2"));
        }
    }
}
