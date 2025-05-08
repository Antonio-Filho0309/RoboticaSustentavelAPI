using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;
using RoboticaSustentavelAPI.Repositories.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ItemSaleController : ControllerBase
{
    private readonly IItemSaleRepository _itemSaleRepository;
    private readonly IMapper _mapper;

    public ItemSaleController(IItemSaleRepository itemSaleRepository, IMapper mapper)
    {
        _itemSaleRepository = itemSaleRepository;
        _mapper = mapper;
    }

    [HttpGet("test")]
    public async Task<IActionResult> TestRepository()
    {
        var itens = await _itemSaleRepository.GetAllItens();

        if (itens == null || itens.Count == 0)
            return NotFound("Nenhum item encontrado");

        var itensDto = _mapper.Map<List<ItemSaleDto>>(itens);
        return Ok(itensDto);
    }

}
