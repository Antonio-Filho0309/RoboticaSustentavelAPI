using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using RoboticaSustentavelAPI.Models;

namespace RoboticaSustentavelAPI.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<ICollection<Sale>> GetAllSales();
        Task<Sale> GetSaleById(int saleId);
        Task<PagedBaseReponse<Sale>> GetAllSalesPaged(Filter saleFilter);
    }
}
