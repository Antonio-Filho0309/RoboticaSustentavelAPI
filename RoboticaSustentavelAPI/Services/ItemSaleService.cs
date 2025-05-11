using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;

namespace RoboticaSustentavelAPI.Services
{
    public class ItemSaleService : IItemSaleService
    {
        private readonly IMapper _mapper;
        private readonly IItemSaleRepository _itemSaleRepository;
        private readonly IComputerRepository _computerRepository;

        public ItemSaleService(IMapper mapper, IItemSaleRepository itemSaleRepository, IComputerRepository computerRepository)
        {
            _mapper = mapper;
            _itemSaleRepository = itemSaleRepository;
            _computerRepository = computerRepository;
        }

        public async Task<ResultService> Create(CreateItemSaleDto createItemSaleDto)
        {
            if (createItemSaleDto == null)
                return ResultService.BadRequest("Objeto deve ser informado!");

            var result = new CreateItemSaleDtoValidator().Validate(createItemSaleDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);

            var Now = DateTime.Now;
            var dateNow = Now.ToString("dd-MM-yyyy HH:mm");

            var sale = new Sale
            {
                SaleDate = DateTime.Parse(dateNow),
                PriceSale = createItemSaleDto.PriceSale
            };

            var item = _mapper.Map<ItemSale>(createItemSaleDto);
            item.SaleId = sale.Id;
            item.Sale = sale;
            item.Status = Models.Enum.StatusComputer.vendido;



            var computer = await _computerRepository.GetComputerById(item.ComputerId);
            if (computer == null)
                return ResultService.BadRequest("Computador não encontrado");

            if (item.Quantity > computer.Quantity)
                return ResultService.BadRequest("Sem estoque suficiente!");

            computer.Quantity -= item.Quantity;

            await _itemSaleRepository.Add(item);
            return ResultService.Ok("Venda Realizada com sucesso!");
        }

        public async Task<ResultService<ICollection<ItemSaleDto>>> Get()
        {
            var sales = await _itemSaleRepository.GetAllItens();
            return ResultService.Ok(_mapper.Map<ICollection<ItemSaleDto>>(sales));
        }

        public async Task<ResultService<ItemSaleDto>> GetById(int id)
        {
            var sale = await _itemSaleRepository.GetItemById(id);
            if (sale == null)
                return ResultService.NotFound<ItemSaleDto>("Doação não encontrada!");

            return ResultService.Ok(_mapper.Map<ItemSaleDto>(sale));
        }

        public async Task<ResultService<List<ItemSaleDto>>> GetPagedAsync(Filter itemFilter)
        {
            var item = await _itemSaleRepository.GetAllItensPaged(itemFilter);
            var result = new PagedBaseResponseDto<ItemSaleDto>(item.TotalRegisters, item.Page, item.NumberOfPages, _mapper.Map<List<ItemSaleDto>>(item.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<ItemSaleDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.Page, result.NumberOfPages);
        }
    }
}
