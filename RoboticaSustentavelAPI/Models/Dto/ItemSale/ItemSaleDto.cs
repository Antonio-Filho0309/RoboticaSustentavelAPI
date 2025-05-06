using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Enum;
using RoboticaSustentavelAPI.Models;
namespace RoboticaSustentavelAPI.Models.Dto.ItemSale;
public class ItemSaleDto
{
    public int Id { get; set; }
    public int ComputerId { get; set; }
    public DonationItemComputerDto Computer { get; set; }
    public int SaleId { get; set; }
    public Sale Sale { get; set; }
    public int Quantity { get; set; }
    public StatusComputer Status { get; set; }
}
