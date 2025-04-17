namespace RoboticaSustentavelAPI.Models
{
    public class ItemDonation
    {
        public ItemDonation() { }

        public ItemDonation(int id, int idComputer,int idDonation, int quantity)
        {
            Id = id;
            IdComputer = idComputer;
            IdDonation = idDonation;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public int IdComputer { get; set; }
        public Computer Computer { get; set; }
        public int IdDonation { get; set; }
        public Donation Donation { get; set; }
        public int Quantity { get; set; }
    }
}
