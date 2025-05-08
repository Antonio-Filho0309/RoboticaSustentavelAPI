using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.FilterDb;
using RoboticaSustentavelAPI.Models.Dto.Sales;

namespace RoboticaSustentavelAPI.Services.Interfaces
{
    public interface ISalesServices
    {
        Task<ResultService<ICollection<SaleDto2>>> Get();
        Task<ResultService<SaleDto2>> GetById(int id);
        Task<ResultService<List<SaleDto2>>> GetPagedAsync(Filter saleFilter);
    }
}
