using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models
{
    public class Computer
    {
        public Computer() { }

        public Computer(int id, string brand,string processor,string ram, string storage, string cPU, int quantity)
        {
            Id = id;
            Brand = brand;
            Processor = processor;
            Ram = ram;
            Storage = storage;
            CPU = cPU;
            Status = 0;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string? Brand { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string CPU { get; set; }
        public StatusComputer? Status { get; set; }
        public int Quantity { get; set; }

        public ICollection<ItemSale> ItensSales { get; set; } =
        new List<ItemSale>();
        public ICollection<ItemDonation> ItensDonation { get; set; } = new List<ItemDonation>();
    }
}