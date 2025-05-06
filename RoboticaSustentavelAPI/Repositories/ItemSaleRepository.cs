using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;

namespace RoboticaSustentavelAPI.Repositories
{
    public class ItemSaleRepository : IItemDonationRepository
    {

        private readonly DataContext _context;

        public ItemSaleRepository(DataContext context)
        {
            _context = context;
        }

        public Task<ItemDonation> Add(ItemDonation itemDonation)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ItemDonation>> GetAllItens()
        {
            throw new NotImplementedException();
        }

        public Task<PagedBaseReponse<ItemDonation>> GetAllItensPaged(Filter itemFilter)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDonation> GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
