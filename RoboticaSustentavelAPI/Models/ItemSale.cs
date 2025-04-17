namespace RoboticaSustentavelAPI.Models
{
    public class ItemSale
    {
        public ItemSale() { }

        public ItemSale(int id, int idComputer,int idSale,int quantity )
        {
            Id = id;
            IdComputer = idComputer;
            IdSale = idSale;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public int IdComputer { get; set; }
        public Computer Computer { get; set; }

        public int IdSale { get; set; }
        public Sale Sale { get; set; }
        public int Quantity { get; set; }
    }
}
