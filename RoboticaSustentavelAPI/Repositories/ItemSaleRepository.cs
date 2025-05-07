using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;

namespace RoboticaSustentavelAPI.Repositories
{
    public class ItemSaleRepository : IItemSaleRepository
    {

        private readonly DataContext _context;

        public ItemSaleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemSale> Add(ItemSale itemSale)
        {
            _context.Add(itemSale);
            await _context.SaveChangesAsync();
            return itemSale;
        }

        public async Task<ICollection<ItemSale>> GetAllItens()
        {
            return await _context.ItemSales.Include(i => i.Sale).Include(i => i.Computer).OrderBy(i => i.Id)
               .ToListAsync();
        }

        public async Task<PagedBaseReponse<ItemSale>> GetAllItensPaged(Filter itemFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemSale> GetItemById(int itemId)
        {
            return await _context.ItemSales.Include(i => i.Computer).Include(i => i.Sale).FirstOrDefaultAsync(i => i.Id == itemId);
        }
    }
}
