namespace RoboticaSustentavelAPI.Models
{
    public class ItemDonation
    {
        public ItemDonation() { }

        public ItemDonation(int id, int computerId,int donationId, int quantity)
        {
            Id = id;
            ComputerId = computerId;
            DonationId = donationId;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
        public int Quantity { get; set; }
    }
}
