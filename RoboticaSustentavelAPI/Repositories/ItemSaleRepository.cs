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
            var itemSale = _context.ItemSales.Include(i => i.Sale).Include(i => i.Computer).AsQueryable();
            if (!string.IsNullOrEmpty(itemFilter.Search))
            {
                var filter = itemFilter.Search.ToLower();

                itemSale = itemSale.Where(i =>
                i.ComputerId.ToString().Contains(filter) ||
                i.SaleId.ToString().Contains(filter) ||
                i.Quantity.ToString().Contains(filter) ||
                i.Computer.Brand.ToLower().Contains(filter) ||
                i.Computer.Processor.ToLower().Contains(filter));
            }
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<ItemSale>, ItemSale>(itemSale, itemFilter);
        }

        public async Task<ItemSale> GetItemById(int itemId)
        {
            return await _context.ItemSales.Include(i => i.Computer).Include(i => i.Sale).FirstOrDefaultAsync(i => i.Id == itemId);
        }
    }
}
