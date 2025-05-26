using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Net;

[ApiController]
[Route("api/[controller]")]
public class ItemSaleController : ControllerBase
{
    private readonly IItemSaleService _itemSaleService;

    public ItemSaleController(IItemSaleService itemSaleService)
    {
        _itemSaleService = itemSaleService;
    }

    /// <summary>
    /// Retorna todos os item de venda cadastrados
    /// </summary>
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _itemSaleService.Get();
        if (result.StatusCode == HttpStatusCode.OK)
            return Ok(result);
        return NotFound(result);
    }


    /// <summary>
    /// Retorna um item de venda  pelo ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var result = await _itemSaleService.GetById(id);
        if (result.StatusCode == HttpStatusCode.OK)
            return Ok(result);
        return NotFound(result);
    }

    /// <summary>
    /// método para paginação
    /// </summary>
    [HttpGet]
    [Route("Paged")]
    public async Task<ActionResult> GetByIdAsync([FromQuery] Filter itemFilter)
    {
        var result = await _itemSaleService.GetPagedAsync(itemFilter);
        if (result.StatusCode == HttpStatusCode.OK)
            return Ok(result);
        return NotFound(result);
    }

    /// <summary>
    /// Cria um novo item de venda
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateItemSaleDto createItemSalenDto)
    {
        var result = await _itemSaleService.Create(createItemSalenDto);
        if (result.StatusCode == HttpStatusCode.OK)
            return StatusCode(201, result);
        return BadRequest(result);
    }
}
