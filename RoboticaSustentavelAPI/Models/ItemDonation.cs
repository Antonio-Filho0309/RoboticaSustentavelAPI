using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using RoboticaSustentavelAPI.Models.Enum;

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
            Status = StatusComputer.doado;
        }

        public int Id { get; set; }
        public int? ComputerId { get; set; }
        public Computer Computer { get; set; }
        public string? Brand { get; set; }
        public string? CPU { get; set; }
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
        public int Quantity { get; set; }
        public StatusComputer Status { get; set; }
    }
}
