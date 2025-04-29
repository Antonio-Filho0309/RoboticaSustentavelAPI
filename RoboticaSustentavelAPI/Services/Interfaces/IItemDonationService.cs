using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.ItemDonation;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IItemDonationService
    {
        Task<ResultService<ICollection<ItemDonationDto>>> Get();
        Task<ResultService<ItemDonationDto>> GetById(int id);
        Task<ResultService> Create(CreateItemDonationDto createItemDonationDto);

        Task<ResultService<List<ItemDonationDto>>> GetPagedAsync(Filter itemFilter);
    }
}
