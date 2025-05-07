using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Repositories.Interfaces;

namespace RoboticaSustentavelAPI.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _context;

        public SaleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PagedBaseReponse<Sale>> GetAllSalesPaged(Filter saleFilter)
        {
            var sales = _context.Sales.AsQueryable();

            if (!string.IsNullOrEmpty(saleFilter.Search))
            {
                var filter = saleFilter.Search.ToLower();


                sales = sales.Where(s =>
                    s.SaleDate.ToString().ToLower().Contains(filter));
            }

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Sale>, Sale>(sales, saleFilter);

        }

        public async Task<ICollection<Sale>> GetAllSales()
        {
            return await _context.Sales.OrderBy(s => s.Id)
            .ToListAsync(); ;
        }

        public async Task<Sale> GetSaleById(int saleId)
        {
            return await _context.Sales.FirstOrDefaultAsync(s => s.Id == saleId);
        }
    }
}
