using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RoboticaSustentavelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemDonationRepository _itemDonationRepository;
        private readonly IItemSaleRepository _itemSaleRepository;
        private readonly IMapper _mapper;

        public ItemController(
            IItemDonationRepository itemDonationRepository,
            IItemSaleRepository itemSaleRepository,
            IMapper mapper)
        {
            _itemDonationRepository = itemDonationRepository;
            _itemSaleRepository = itemSaleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna os 4 últimos computadores,vendidos ou doados
        /// </summary>
        [HttpGet("ItemList")]
        public async Task<IActionResult> GetItemList()
        {
            var itemDonations = await _itemDonationRepository.GetAllItens();
            var itemDonationsDto = itemDonations.Select(i => _mapper.Map<Item>(i));

            var itemSales = await _itemSaleRepository.GetAllItens();
            var itemSalesDto = itemSales.Select(i => _mapper.Map<Item>(i));

            var itemList = itemDonationsDto
                .Concat(itemSalesDto)
                .OrderByDescending(i => i.Date)
                .Take(4)
                .ToList();

            return Ok(itemList);
        }


    }
}
