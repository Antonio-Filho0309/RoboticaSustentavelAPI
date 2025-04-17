namespace RoboticaSustentavelAPI.Models
{
    public class Donation
    {
            public Donation() { }
            public Donation(int id, DateTime dateDonation)
            {
                Id = id;
                DateDonation = dateDonation;
            }

            public int Id { get; set; }
            public DateTime DateDonation { get; set; }

        public ICollection<ItemDonation> ItensDonations { get; set; } = new List<ItemDonation>();
        }
    
}
