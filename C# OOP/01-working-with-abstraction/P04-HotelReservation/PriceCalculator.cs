namespace P04_HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int daysCount;
        private Season season;
        private Discount discount;

        public PriceCalculator(decimal pricePerDay, int daysCount, Season season, Discount discount)
        {
            this.pricePerDay = pricePerDay;
            this.daysCount = daysCount;
            this.season = season;
            this.discount = discount;
        }

        public decimal CalculatePrice()
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal priceBeforeDiscount = daysCount * pricePerDay * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}
