namespace RoboticaSustentavelAPI.Models
{
    public class Sale
    {
        public Sale() { }

        public Sale(int id, DateTime saleDate, double priceSale)
        {
            Id = id;
            SaleDate = saleDate;
            PriceSale = priceSale;
        }

        public int Id { get; set; }

        public DateTime SaleDate { get; set; }
        public double PriceSale { get; set; }

        public ICollection<ItemSale> ItensSales { get; set; } = new List<ItemSale>();
    }
}
