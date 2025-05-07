using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Repositories.Interfaces
{
    public interface IItemSaleRepository
    {
        Task<ItemSale> Add(ItemSale itemSale);
        Task<ICollection<ItemSale>> GetAllItens();
        Task<ItemSale> GetItemById(int itemId);
        Task<PagedBaseReponse<ItemSale>> GetAllItensPaged(Filter itemFilter);
    }
}
