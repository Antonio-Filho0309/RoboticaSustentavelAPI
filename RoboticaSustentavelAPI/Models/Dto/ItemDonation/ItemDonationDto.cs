using RoboticaSustentavelAPI.Models.Dto.Computer;

namespace RoboticaSustentavelAPI.Models.Dto.ItemDonation
{
    public class ItemDonationDto
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public DonationItemComputerDto Computer { get; set; }
        public int DonationId { get; set; }
        public  Donation Donation { get; set; }
        public int Quantity { get; set; }
    }
}
