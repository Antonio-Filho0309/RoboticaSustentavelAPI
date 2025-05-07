using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models.Dto.ItemSale
{
    public class CreateItemSaleDto
    {
        public int ComputerId { get; set; }
        public double PriceSale { get; set; }
        public int Quantity { get; set; }
    }
}
