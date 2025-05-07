using Microsoft.AspNetCore.Mvc;
using RoboticaSustentavelAPI.Repositories.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ItemSaleController : ControllerBase
{
    private readonly IItemSaleRepository _itemSaleRepository;

    public ItemSaleController(IItemSaleRepository itemSaleRepository)
    {
        _itemSaleRepository = itemSaleRepository;
    }

    [HttpGet("test")]
    public async Task<IActionResult> TestRepository()
    {
        var itens = await _itemSaleRepository.GetAllItens();

        if (itens == null || itens.Count == 0)
            return NotFound("Nenhum item encontrado");

        return Ok(itens); // Aqui você retorna direto o resultado do repositório
    }
}
