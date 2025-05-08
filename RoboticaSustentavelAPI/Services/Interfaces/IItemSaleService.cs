using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.ItemSale;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface IItemSaleService
    {
        Task<ResultService<ICollection<ItemSaleDto>>> Get();
        Task<ResultService<ItemSaleDto>> GetById(int id);
        Task<ResultService> Create(CreateItemSaleDto createItemSaleDto);
        Task<ResultService<List<ItemSaleDto>>> GetPagedAsync(Filter itemFilter);
    }
}