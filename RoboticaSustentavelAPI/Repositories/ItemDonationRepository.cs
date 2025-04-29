using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;

namespace RoboticaSustentavelAPI.Repositories
{
    public class ItemDonationRepository : IItemDonationRepository
    {
        private readonly DataContext _context;

        public ItemDonationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemDonation> Add(ItemDonation itemDonation)
        {
            _context.Add(itemDonation);
            await _context.SaveChangesAsync();
            return itemDonation;
        }

        public async Task<ICollection<ItemDonation>> GetAllItens()
        {
            return await _context.ItemDonations.Include(i => i.Donation).Include(i => i.Computer).OrderBy(i => i.Id)
               .ToListAsync();
        }

        public async Task<ItemDonation> GetItemById(int itemId)
        {
            return await _context.ItemDonations.Include(i => i.Donation).Include(i => i.Computer).FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<PagedBaseReponse<ItemDonation>> GetAllItensPaged(Filter itemFilter)
        {
            var itemDonation = _context.ItemDonations.Include(i => i.Donation).Include(i => i.Computer).AsQueryable();
            if (!string.IsNullOrEmpty(itemFilter.Search))
            {
                var filter = itemFilter.Search.ToLower();

                itemDonation = itemDonation.Where(i =>
                i.DonationId.ToString().Contains(filter) ||
                i.ComputerId.ToString().Contains(filter) ||
                i.Quantity.ToString().Contains(filter) ||
                i.Computer.Brand.ToLower().Contains(filter) ||
                i.Computer.Processor.ToLower().Contains(filter));
            }
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<ItemDonation>, ItemDonation>(itemDonation, itemFilter);
        }
    }
}
