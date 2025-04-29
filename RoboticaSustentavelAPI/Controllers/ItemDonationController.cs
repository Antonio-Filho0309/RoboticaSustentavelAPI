using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;
using RoboticaSustentavelAPI.Services.Interfaces;
using System.Net;

namespace RoboticaSustentavelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemDonationController : ControllerBase
    {
        private readonly IItemDonationService _itemDonationService;

        public ItemDonationController(IItemDonationService itemDonationService)
        {
            _itemDonationService = itemDonationService;
        }

        /// <summary>
        /// Retorna todos os item de doação cadastrados
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _itemDonationService.Get();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Retorna um item de doação pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _itemDonationService.GetById(id);
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
            var result = await _itemDonationService.GetPagedAsync(itemFilter);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        /// <summary>
        /// Cria um novo item de doação
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateItemDonationDto createItemDonationDto)
        {
            var result = await _itemDonationService.Create(createItemDonationDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);
            return BadRequest(result);
        }



    }
}
