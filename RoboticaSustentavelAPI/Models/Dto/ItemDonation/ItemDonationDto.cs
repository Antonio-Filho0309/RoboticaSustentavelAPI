using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Enum;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.Donation;

namespace RoboticaSustentavelAPI.Models.Dto.ItemDonation
{
    public class ItemDonationDto
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public string? Brand { get; set; }
        public string CPU { get; set; }
        public int DonationId { get; set; }
        public  DonationDto Donation { get; set; }
        public int Quantity { get; set; }
        public StatusComputer Status { get; set; }
    }
}
