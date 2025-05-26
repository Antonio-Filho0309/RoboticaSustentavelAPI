using RoboticaSustentavelAPI.Models.Dto.Computer;
using RoboticaSustentavelAPI.Models.Dto.Sales;
using RoboticaSustentavelAPI.Models.Enum;
namespace RoboticaSustentavelAPI.Models.Dto.ItemSale;
public class ItemSaleDto
{
    public int Id { get; set; }
    public int ComputerId { get; set; }
    public string? Brand { get; set; }
    public string CPU { get; set; }
    public int SaleId { get; set; }
    public SaleDto Sale { get; set; }
    public int Quantity { get; set; }
    public StatusComputer Status { get; set; }
}
