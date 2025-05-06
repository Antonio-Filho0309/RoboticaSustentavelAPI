using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Repositories.Interfaces
{
    public interface IItemDonationRepository
    {
            Task<ItemDonation> Add(ItemDonation itemDonation);
            Task<ICollection<ItemDonation>> GetAllItens();
            Task<ItemDonation> GetItemById(int itemId);
            Task<PagedBaseReponse<ItemDonation>> GetAllItensPaged(Filter itemFilter);
    }
}
