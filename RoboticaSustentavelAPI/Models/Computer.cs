using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models
{
    public class Computer
    {
        public Computer() { }

        public Computer(int id, string brand,string cPU,string ram, string storage, int quantity)
        {
            Id = id;
            Brand = brand;
            CPU = cPU;
            Ram = ram;
            Storage = storage;
            Status = 0;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string? Brand { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public StatusComputer? Status { get; set; }
        public int Quantity { get; set; }

        public ICollection<ItemSale> ItensSales { get; set; } =
        new List<ItemSale>();
        public ICollection<ItemDonation> ItensDonation { get; set; } = new List<ItemDonation>();
    }
}