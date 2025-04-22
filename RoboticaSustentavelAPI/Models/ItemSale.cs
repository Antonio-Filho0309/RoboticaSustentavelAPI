namespace RoboticaSustentavelAPI.Models
{
    public class ItemSale
    {
        public ItemSale() { }

        public ItemSale(int id, int computerId,int saleId,int quantity )
        {
            Id = id;
            ComputerId = computerId;
            SaleId = saleId;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public int ComputerId { get; set; }
        public Computer Computer { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int Quantity { get; set; }
    }
}
