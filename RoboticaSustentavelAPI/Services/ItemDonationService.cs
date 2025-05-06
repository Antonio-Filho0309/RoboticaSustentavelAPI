using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;
using RoboticaSustentavelAPI.Repositories.Interfaces;
using RoboticaSustentavelAPI.Services.Interfaces;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models.Dtos;

namespace RoboticaSustentavelAPI.Services
{
    public class ItemDonationService : IItemDonationService
        
    {
        private readonly IMapper _mapper;
        private readonly IItemDonationRepository _itemDonationRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IComputerRepository _computerRepository;

        public ItemDonationService(IMapper mapper, IItemDonationRepository itemDonationRepository, IDonationRepository donationRepository, IComputerRepository computerRepository)
        {
            _mapper = mapper;
            _itemDonationRepository = itemDonationRepository;
            _donationRepository = donationRepository;
            _computerRepository = computerRepository;
        }
        public async Task<ResultService> Create(CreateItemDonationDto createItemDonationDto)
        {
            if (createItemDonationDto == null)
                return ResultService.BadRequest("Objeto deve ser informado!");

            var result = new CreateItemDonationDtoValidator().Validate(createItemDonationDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);

            var Now = DateTime.Now;
            var dateNow = Now.ToString("dd-MM-yyyy HH:mm");

            var donation = new Donation
            {
                DateDonation = DateTime.Parse(dateNow)
            };

            var item = _mapper.Map<ItemDonation>(createItemDonationDto);
            item.DonationId = donation.Id;
            item.Donation = donation;
            


            var computer = await _computerRepository.GetComputerById(item.ComputerId);
            if(computer == null)
                return ResultService.BadRequest("Computador não encontrado");
            
            if (computer.Quantity < 0)
                return ResultService.BadRequest("Sem Computador no estoque");

            if (item.Quantity > computer.Quantity)
                return ResultService.BadRequest("Quantidade é maior do que a registrada no estoque");

            computer.Quantity -= item.Quantity;

            await _itemDonationRepository.Add(item);
            return ResultService.Ok("Doação Realizada com sucesso!");
        }

        public async Task<ResultService<ICollection<ItemDonationDto>>> Get()
        {
            var itens = await _itemDonationRepository.GetAllItens();
            return ResultService.Ok(_mapper.Map<ICollection<ItemDonationDto>>(itens));
        }

        public async Task<ResultService<ItemDonationDto>> GetById(int id)
        {
            var item = await _itemDonationRepository.GetItemById(id);
            if (item == null)
                return ResultService.NotFound<ItemDonationDto>("Item de doação não encontrado");
            return ResultService.Ok(_mapper.Map<ItemDonationDto>(item));
        }

        public async Task<ResultService<List<ItemDonationDto>>> GetPagedAsync(Filter itemFilter)
        {
            var item = await _itemDonationRepository.GetAllItensPaged(itemFilter);
            var result = new PagedBaseResponseDto<ItemDonationDto>(item.TotalRegisters, item.TotalPages, item.PageNumber, _mapper.Map<List<ItemDonationDto>>(item.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<ItemDonationDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }
    }
}
